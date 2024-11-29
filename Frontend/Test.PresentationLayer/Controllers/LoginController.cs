using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Concrete.AppUser;
using System.Security.Claims;
using Test.PresentationLayer.Models;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public LoginController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel loginViewModel, string? returnUrl = null)
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        try
        {
            var loginRequest = new LoginRequest
            {
                Username = loginViewModel.Username,
                Password = loginViewModel.Password
            };
            var response = await client.PostAsJsonAsync("/api/AppUser/Login", loginRequest);
            if (!response.IsSuccessStatusCode)
            {
                // Hata durumunda API'den gelen mesajı göster
                var errorResponse = await response.Content.ReadAsStringAsync();
                var error = JsonConvert.DeserializeObject<ErrorResponse>(errorResponse);
                ModelState.AddModelError(string.Empty, error.Message);
                return View(loginViewModel); // Hata ile birlikte yeniden formu göster
            }
            var responseBody = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

            switch (loginResponse.IsEmailConfirmed)
            {
                case true:
                    await SetUserSessionAndCookie(loginResponse);
                    break;
                    case false:
                    HttpContext.Session.SetString("Email", loginResponse.Email);
                    HttpContext.Session.SetInt32("Id", loginResponse.Id);
                    break;
            }
            var redirectUrl = !string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl) ? returnUrl : loginResponse.RedirectTo;

            return Redirect(redirectUrl);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Bir hata oluştu: {ex.Message}");
        }
        return View(loginViewModel);
    }

    private async Task SetUserSessionAndCookie(LoginResponse? loginResponse)
    {
        HttpContext.Session.SetString("UserName", loginResponse.UserName);
        HttpContext.Session.Set("ImageURL", loginResponse.ImageURL);
        HttpContext.Session.SetString("Token", loginResponse.Token); // Token'ı saklama
        HttpContext.Session.SetInt32("Id", loginResponse.Id);

        // Authentication Cookie Ayarı
        var claims = new List<Claim>
                     {
                     new Claim(ClaimTypes.Name, loginResponse.UserName),
                     new Claim("Token", loginResponse.Token),
                         new Claim(ClaimTypes.NameIdentifier, loginResponse.Id.ToString())
                     };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }
}
