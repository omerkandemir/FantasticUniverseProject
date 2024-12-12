using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLayer.Mapper.Responses.Concrete.AppUser;
using System.Security.Claims;
using AdminSphere.Models;
using NLayer.Mapper.Requests.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AdminSphere.Controllers;

public class AdminLoginController : AdminBaseController
{
    private readonly IHttpClientFactory _httpClientFactory;
    public AdminLoginController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel loginViewModel)
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        try
        {
            var loginRequest = new LoginRequest
            {
                Username = loginViewModel.Username,
                Password = loginViewModel.Password
            };
            var response = await client.PostAsJsonAsync("/api/AppUser/AdminLogin", loginRequest);
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorResponse>(errorResponse);
                ModelState.AddModelError(string.Empty, error.Message);
                return View(loginViewModel); 
            }
            var responseBody = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseBody);
            await SetUserSessionAndCookie(loginResponse);
            return RedirectToAction("Index", "Dashboard");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Bir hata oluştu: {ex.Message}");
        }
        return View(loginViewModel);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PostAsync("/api/AppUser/Logout", null);

        if (response.IsSuccessStatusCode)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "AdminLogin");
        }
        TempData["ErrorMessage"] = "Çıkış işlemi başarısız oldu!";
        return View();
    }
    private async Task SetUserSessionAndCookie(LoginResponse? loginResponse)
    {
        HttpContext.Session.SetString("Email", loginResponse.Email);
        HttpContext.Session.SetString("UserName", loginResponse.UserName);
        HttpContext.Session.Set("ImageURL", loginResponse.ImageURL);
        HttpContext.Session.SetString("Token", loginResponse.Token); // Token'ı saklama
        HttpContext.Session.SetInt32("Id", loginResponse.Id);
        HttpContext.Session.SetString("UserRoles", string.Join(",", loginResponse.Roles)); 

        var claims = new List<Claim>
                     {
                     new Claim(ClaimTypes.Name, loginResponse.UserName),
                     new Claim("Token", loginResponse.Token),
                         new Claim(ClaimTypes.NameIdentifier, loginResponse.Id.ToString())
                     };

        foreach (var role in loginResponse.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }
}
