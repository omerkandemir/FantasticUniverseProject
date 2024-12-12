using Autofac.Extensions.DependencyInjection;
using Autofac;
using NLayer.Dto.Autofac;
using NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.AppUserValidation;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Middleware;
using NLayer.DataAccess.Concretes.EntityFramework;
using NLayer.Core.Utilities.UserOperations;
using NLayer.Core.Entities.Authorization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Autofac Konfigürasyonu
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

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.WithOrigins("https://localhost:7184")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
        var app = builder.Build();

        // IHttpContextAccessor yapýlandýrmasý
        var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
        AccessUser.Configure(httpContextAccessor); // Configure metodu burada çaðrýlýyor

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
        app.UseCors("AllowAll");
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<UserContextMiddleware>();
        app.MapControllers();

        app.Run();
    }
}