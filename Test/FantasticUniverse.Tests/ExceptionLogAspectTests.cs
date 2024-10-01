using Castle.DynamicProxy;
using Moq;
using NLayer.Core.Aspect.Autofac.Logging;
using NLayer.Core.CrossCuttingConcern.Logging;
using NLayer.Core.CrossCuttingConcern.Logging.LogDetails;

namespace FantasticUniverse.Tests;

public class ExceptionLogAspectTests
{
    private readonly Mock<ILoggerService> _mockLoggerService;
    private readonly ProxyGenerator _proxyGenerator;

    public ExceptionLogAspectTests()
    {
        _mockLoggerService = new Mock<ILoggerService>();
        _proxyGenerator = new ProxyGenerator();
    }

    [Fact]
    public void OnException_ShouldLogError_WithCorrectDetails()
    {
        // Hazırlama
        var exceptionLogAspect = new ExceptionLogAspect(_mockLoggerService.Object); 
        var realObject = new TestExceptionLogAspectClassWithException();

        // Proxy oluşturarak ExceptionLogAspect kullanımı
        var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget<IExceptionLogAspectTestClass>(
            realObject, exceptionLogAspect);

        // Eylem
        Exception exception = Assert.Throws<Exception>(() => proxy.TestMethod("testParam", 42));

        // Doğrulama
        _mockLoggerService.Verify(l => l.LogError(
            "An exception occurred",
            It.Is<LogDetailWithException>(logDetail =>
                logDetail.MethodName == "TestMethod" &&
                logDetail.LogParameters.Any(p => p.Name == "param1" && p.Value.Equals("testParam")) &&
                logDetail.LogParameters.Any(p => p.Name == "param2" && p.Value.Equals(42)) &&
                logDetail.ExceptionMessage == "Test exception"
            )
        ), Times.Once);
    }

    // Test edilecek interface
    public interface IExceptionLogAspectTestClass
    {
        void TestMethod(string param1, int param2);
    }

    // Hata fırlatan sınıf
    public class TestExceptionLogAspectClassWithException : IExceptionLogAspectTestClass
    {
        public virtual void TestMethod(string param1, int param2)
        {
            throw new Exception("Test exception");
        }
    }
}
