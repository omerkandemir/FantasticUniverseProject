using Autofac;
using Autofac.Extensions.DependencyInjection;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation;
using NLayer.Core.Entities.Authentication;
using NLayer.DataAccess.Concretes.EntityFramework;
using NLayer.Dto.Autofac;

namespace Test.PresentationLayer;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        // Database context ve Identity configurasyonu
        services.AddDbContext<FantasticUniverseProjectContext>();

        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<FantasticUniverseProjectContext>()
            .AddErrorDescriber<CustomIdentityValidator>();

        // .NET Core DI kullanarak Autofac'a geçiş yapacağız.
        services.AddAutofac();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        // Autofac modüllerini burada kaydediyoruz.
        builder.RegisterModule<AutofacDtoMudule>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Register}/{action=Index}/{id?}");
        });
    }
}
