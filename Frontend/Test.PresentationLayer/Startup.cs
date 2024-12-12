using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Entities.Authorization;
using NLayer.Core.Helpers;
using NLayer.Core.Middleware;
using NLayer.Core.Utilities.UserOperations;
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
        //// Session servisini ekleme
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout duration
            options.Cookie.HttpOnly = true; // Make the session cookie HTTP-only
            options.Cookie.IsEssential = true; // Make the session cookie essential
        });

        services.AddHttpContextAccessor();

        services.AddControllersWithViews();

        // Database context ve Identity configurasyonu
        services.AddDbContext<FantasticUniverseProjectContext>();

        services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<FantasticUniverseProjectContext>()
            .AddErrorDescriber<CustomIdentityValidator>();

        // .NET Core DI kullanarak Autofac'a geçiş yapacağız.
        services.AddAutofac();

        var apiBaseUrl = Configuration["API:BaseUrl"];
        services.AddHttpClient("APIClient", client =>
        {
            client.BaseAddress = new Uri(apiBaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        // Cookie Authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
            .AddCookie(options =>
            {
                options.LoginPath = "/Login/Index";
                options.AccessDeniedPath = "/Login/AccessDenied";
                options.Cookie.Name = "UserAuthCookie";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.SlidingExpiration = true;
            });
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

        var rootPath = PathHelper.FindParentDirectory(AppContext.BaseDirectory, "FantasticUniverseProject");
        var staticFilesPath = Path.Combine(rootPath, "node-app", "dist");
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(staticFilesPath),
            RequestPath = "/dist" 
        });

        var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
        AccessUser.Configure(httpContextAccessor);

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession(); // Session middleware'i etkinleştir
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<UserContextMiddleware>();




        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");
        });
    }
}
