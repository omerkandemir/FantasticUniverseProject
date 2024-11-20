using Autofac.Extensions.DependencyInjection;
using Autofac;
using WebApi;
using NLayer.Dto.Autofac;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Middleware;
using NLayer.DataAccess.Concretes.EntityFramework;
using Autofac.Core;
using NLayer.Core.Utilities.UserOperations;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Autofac Konfig�rasyonu
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            containerBuilder.RegisterModule<AutofacDtoMudule>();
        });

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<FantasticUniverseProjectContext>();
        builder.Services.AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<FantasticUniverseProjectContext>()
            .AddErrorDescriber<CustomIdentityValidator>();

        builder.Services.AddAutofac();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Fantastic Universe API",
                Version = "v1"
            });
        });

        var app = builder.Build();

        // IHttpContextAccessor yap�land�rmas�
        var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
        AccessUser.Configure(httpContextAccessor); // Configure metodu burada �a�r�l�yor

        // Pipeline Configuration
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fantastic Universe API v1"));
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<UserContextMiddleware>();
        app.MapControllers();

        app.Run();
    }
}