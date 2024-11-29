using Microsoft.AspNetCore.Http;
using NLayer.Core.Utilities.IOC;
using System.Diagnostics;
using Autofac;
using NLayer.Core.Utilities.ImageOperations;
using NLayer.Core.Authentication.Abstracts;
using NLayer.Core.Authentication.Concrete;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Security.Hashing;
using NLayer.Core.Security.Jwt;
using Microsoft.Extensions.Configuration;

namespace NLayer.Core.DependencyRevolvers;

public class CoreModule : IModule
{
    public void Load(ContainerBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        builder.RegisterInstance(jwtSettings).AsSelf().SingleInstance();


        if (jwtSettings == null)
        {
            throw new ArgumentNullException(nameof(jwtSettings), "JwtSettings configuration is missing.");
        }

        // Middleware'in bağımlılığı olan IHttpContextAccessor kaydı
        builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

        builder.RegisterType<GetDefaultImages>().As<IGetDefaultImages>().SingleInstance();
        builder.RegisterType<Stopwatch>().SingleInstance();

        builder.RegisterType<SignInManagerAdapter>().As<ISignInService<AppUser>>();
        builder.RegisterType<UserManagerAdapter>().As<IUserService<AppUser>>();

        builder.RegisterType<JwtTokenService>().As<ITokenService>().SingleInstance();
        builder.RegisterType<HashingService>().As<IHashingService>().SingleInstance();


    }
}
