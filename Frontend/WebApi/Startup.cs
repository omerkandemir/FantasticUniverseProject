using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Middleware;
using NLayer.DataAccess.Concretes.EntityFramework;
using NLayer.Dto.Autofac;

namespace WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {

        //// Session servisini ekleme
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout duration
            options.Cookie.HttpOnly = true; // Make the session cookie HTTP-only
            options.Cookie.IsEssential = true; // Make the session cookie essential
        });

        services.AddHttpContextAccessor();

        services.AddDbContext<FantasticUniverseProjectContext>();
        services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<FantasticUniverseProjectContext>()
                .AddErrorDescriber<CustomIdentityValidator>(); ;

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
        });

        var builder = new ContainerBuilder();
        builder.Populate(services); // .NET Core servislerini Autofac'e kopyala
        builder.RegisterModule<AutofacDtoMudule>(); // AutoMapper modülünü kaydet
        var container = builder.Build();
        var serviceProvider = new AutofacServiceProvider(container);

        // Servis sağlayıcısını ayarla
        services.AddAutofac();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSession(); // Session middleware'i etkinleştir

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseMiddleware<UserContextMiddleware>();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
        }

        app.UseRouting();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
