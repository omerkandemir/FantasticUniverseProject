using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Authentication;
using Test.PresentationLayer.Models;

namespace Test.PresentationLayer.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel loginViewModel)
    {
        var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, true, true);
        if (result.Succeeded)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user.EmailConfirmed == true)
            {
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.SetString("ImageUrl", user.ImageUrl);
                return RedirectToAction("Index", "MainPage");
            }//Lütfen Mail Adresinizi onaylayınız
        }//kullanıcı adı veya şifre hatalı
        return View();
    }
}
