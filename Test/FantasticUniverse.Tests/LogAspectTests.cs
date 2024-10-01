using Moq;
using NLayer.Core.Aspect.Autofac.Logging;
using NLayer.Core.CrossCuttingConcern.Logging.LogDetails;
using NLayer.Core.CrossCuttingConcern.Logging;
using Castle.DynamicProxy;

namespace FantasticUniverse.Tests;


public class LogAspectTests
{
    private readonly Mock<ILoggerService> _mockLoggerService;
    private readonly ProxyGenerator _proxyGenerator;

    public LogAspectTests()
    {
        _mockLoggerService = new Mock<ILoggerService>();
        _proxyGenerator = new ProxyGenerator();
    }

    [Fact]
    public void OnAfter_ShouldLogInformation_WithCorrectDetails()
    {
        // Hazırlama
        var logAspect = new LogAspect(_mockLoggerService.Object);  
        var realObject = new TestLogAspectClass();

        // Proxy oluşturarak LogAspect kullanımı
        var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget<ITestLogAspectClass>(
            realObject, logAspect);

        // Eylem
        proxy.TestMethod("testParam", 42);

        // Doğrulama
        _mockLoggerService.Verify(l => l.LogInformation(
            "Method execution completed",
            It.Is<LogDetail>(logDetail => logDetail.MethodName == "TestLogAspectClass.TestMethod"  
                                           && logDetail.LogParameters.Any(p => p.Name == "param1" && p.Value.Equals("testParam"))
                                           && logDetail.LogParameters.Any(p => p.Name == "param2" && p.Value.Equals(42)))), Times.Once);
    }

    [Fact]
    public void OnException_ShouldLogError_WithExceptionDetails()
    {
        // Hazırlama
        var logAspect = new LogAspect(_mockLoggerService.Object);  
        var realObject = new TestLogAspectClassWithException();

        // Proxy oluşturarak LogAspect kullanımı
        var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget<ITestLogAspectClass>(
            realObject, logAspect);

        // Eylem
        Exception exception = Assert.Throws<Exception>(() => proxy.TestMethod("testParam", 42));

        // Doğrulama
        _mockLoggerService.Verify(l => l.LogError(
            It.IsAny<string>(),
            It.IsAny<LogDetailWithException>()), Times.Once);
    }

    // Test edilecek interface
    public interface ITestLogAspectClass
    {
        void TestMethod(string param1, int param2);
    }

    // Gerçek sınıf
    public class TestLogAspectClass : ITestLogAspectClass
    {
        public virtual void TestMethod(string param1, int param2)
        {
        }
    }

    // Hata fırlatan sınıf
    public class TestLogAspectClassWithException : ITestLogAspectClass
    {
        public virtual void TestMethod(string param1, int param2)
        {
            throw new Exception("Test exception");
        }
    }
}

