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

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

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
var apiBaseUrl = builder.Configuration["API:BaseUrl"];
builder.Services.AddHttpClient("APIClient", client =>
    {
        client.BaseAddress = new Uri(apiBaseUrl);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    });
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    })
            .AddCookie(options =>
            {
                options.LoginPath = "/AdminLogin/Index";
                options.AccessDeniedPath = "/AdminLogin/AccessDenied";
                options.Cookie.Name = "AdminAuthCookie";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.SlidingExpiration = true;
            });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule<AutofacDtoMudule>();
}); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
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
var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
AccessUser.Configure(httpContextAccessor);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<UserContextMiddleware>();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AdminLogin}/{action=Index}/{id?}");

app.Run();
