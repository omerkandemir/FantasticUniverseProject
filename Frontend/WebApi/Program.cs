using Autofac.Extensions.DependencyInjection;
using Autofac;
using WebApi;
using NLayer.Dto.Autofac;

internal class Program
{
    private static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
           .UseServiceProviderFactory(new AutofacServiceProviderFactory()).
            ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacDtoMudule());
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
}