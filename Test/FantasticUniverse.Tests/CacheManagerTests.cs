using Autofac;
using Castle.DynamicProxy;
using Moq;
using NLayer.Core.Aspect.Autofac.Caching;
using NLayer.Core.CrossCuttingConcern.Caching;
using NLayer.Core.CrossCuttingConcern.Caching.Redis;
using NLayer.Core.Utilities.IOC;
using StackExchange.Redis;

namespace FantasticUniverse.Tests;

public class CacheManagerTests
{
    private readonly CacheAspect _cacheAspect;
    private readonly Mock<ICacheManager> _cacheManagerMock;
    private readonly Mock<IDatabase> _redisDbMock;
    private readonly RedisCacheManager _redisCacheManager;

    public CacheManagerTests()
    {
        // Mock ICacheManager
        _cacheManagerMock = new Mock<ICacheManager>();

        // Autofac ile mock'u container'a kaydediyoruz
        var builder = new ContainerBuilder();
        builder.RegisterInstance(_cacheManagerMock.Object).As<ICacheManager>().SingleInstance();

        // Container'ı oluşturuyoruz ve AutofacServiceTool'a set ediyoruz
        var container = builder.Build();
        AutofacServiceTool.SetContainer(container);

        // CacheAspect instance
        _cacheAspect = new CacheAspect();

        // Mock IDatabase
        _redisDbMock = new Mock<IDatabase>();

        // Mock IConnectionMultiplexer
        var connectionMultiplexerMock = new Mock<IConnectionMultiplexer>();
        connectionMultiplexerMock.Setup(m => m.GetDatabase(It.IsAny<int>(), It.IsAny<object>()))
                                 .Returns(_redisDbMock.Object);

        // RedisCacheManager instance
        _redisCacheManager = new RedisCacheManager(connectionMultiplexerMock.Object);
    }

    [Fact]
    public void Should_AddData_To_Cache_Using_RealProxy() //gerçek bir sınıfın proxy'si üzerinden CacheAspect'in doğru çalışıp çalışmadığının kontrolü.
    {
        // Hazırlama
        var proxyGenerator = new ProxyGenerator();
        var realObject = new TestClass(); // Test etmek istediğimiz gerçek sınıf

        // Cache'de bu anahtarın olmadığının simüle edilmesi
        _cacheManagerMock.Setup(x => x.IsAdd(It.IsAny<string>())).Returns(false);

        // Real proxy'yi oluşturuyoruz ve CacheAspect ile proxy'lenmiş sınıfı oluşturuyoruz
        var proxy = proxyGenerator.CreateInterfaceProxyWithTarget<ITestClass>(
            realObject, _cacheAspect);

        // Eylem - Proxy'lenmiş sınıftaki metodu çağırıyoruz
        var result = proxy.GetData();

        // Doğrulama - Sonucun doğru şekilde döndüğünün kontrol edilmesi
        Assert.Equal("Data from real object", result);

        // Cache'e eklendiğinin doğrulanması
        _cacheManagerMock.Verify(x => x.Add(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void Should_AddData_To_Cache_IfNotExists() // Cache'de bulunmayan bir anahtar için veri eklenmesinin test edilmesi.
    {
        // Hazırlama
        var proxyGenerator = new ProxyGenerator();
        var realObject = new TestClass(); // Test etmek istediğimiz gerçek sınıf
        var returnValue = "Data from real object";

        // Cache'de bu anahtarın olmadığının test edilmesi
        _cacheManagerMock.Setup(x => x.IsAdd(It.IsAny<string>())).Returns(false);

        // Real proxy'yi oluşturuyoruz ve CacheAspect ile proxy'lenmiş sınıfı oluşturuyoruz
        var proxy = proxyGenerator.CreateInterfaceProxyWithTarget<ITestClass>(
            realObject, _cacheAspect);

        // Eylem - Proxy'lenmiş sınıftaki metodu çağırıyoruz
        var result = proxy.GetData();

        // Doğrulama - Sonucun doğru şekilde döndüğünün kontrol edilmesi
        Assert.Equal(returnValue, result);

        // Cache'e eklenip eklenmediğinin kontrol edilmesi
        _cacheManagerMock.Verify(x => x.Add(It.IsAny<string>(), returnValue, It.IsAny<int>()), Times.Once);
    }



    [Fact]
    public void Should_Return_Data_From_Cache_If_Key_Exists() // Cache'den veri çekilmesini ve JSON formatında döndürülmesinin test edilmesi.
    {
        // Hazırlama
        var key = "testKey";
        var cachedData = "cachedData";

        var jsonCachedData = Newtonsoft.Json.JsonConvert.SerializeObject(cachedData);

        // RedisValue olarak JSON formatındaki cachedData'nın ayarlanması
        RedisValue redisValue = jsonCachedData;

        // Redis'den veri döndürme
        _redisDbMock.Setup(db => db.StringGet(key, CommandFlags.None)).Returns(redisValue);

        // Eylem
        var result = _redisCacheManager.Get<string>(key);

        // Doğrulama
        Assert.Equal(cachedData, result);
    }



    [Fact]
    public void Should_Return_Default_If_Key_Does_Not_Exist() // Redis'de olmayan bir anahtar için varsayılan değerin döndürülmesi.
    {
        // Hazırlama
        var key = "nonExistingKey";
        _redisDbMock.Setup(db => db.StringGet(key, CommandFlags.None)).Returns(RedisValue.Null);

        // Eylem
        var result = _redisCacheManager.Get<string>(key);

        // Doğrulama
        Assert.Null(result);
    }



    [Fact]
    public void Should_Remove_Cache_Entries_By_Pattern_On_Success() // CacheRemoveAspect'in başarılı olduğu durumda cache'deki anahtarları temizleyip temizlemediğinin kontrol edilmesi.
    {
        // Hazırlama
        var pattern = "testPattern";
        var cacheManagerMock = new Mock<ICacheManager>();

        // Autofac ile mock'u container'a kaydediyoruz
        var builder = new ContainerBuilder();

        // ICacheManager Mock'unu Autofac'e kaydediyoruz
        builder.RegisterInstance(cacheManagerMock.Object).As<ICacheManager>().SingleInstance();

        var container = builder.Build();
        AutofacServiceTool.SetContainer(container);

        // CacheRemoveAspect oluşturuluyor
        var cacheRemoveAspect = new CacheRemoveAspect(pattern);

        var invocationMock = new Mock<Castle.DynamicProxy.IInvocation>();

        // Proceed metodunun başarılı olacağının simüle edilmesi
        invocationMock.Setup(i => i.Proceed());

        // Eylem
        cacheRemoveAspect.Intercept(invocationMock.Object);

        // Doğrulama - Proceed'in çağrıldığının doğrulanması
        invocationMock.Verify(i => i.Proceed(), Times.Once);

        // Doğrulama - RemoveByPattern'in çağrıldığının doğrulanması
        cacheManagerMock.Verify(c => c.RemoveByPattern(pattern), Times.Once);
    }
}
// Test edeceğimiz sınıf ve interface
public interface ITestClass
{
    string GetData();
}

public class TestClass : ITestClass
{
    public virtual string GetData()
    {
        return "Data from real object";
    }
}
