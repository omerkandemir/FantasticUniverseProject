using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Authentication;
using Test.PresentationLayer.Models;

namespace Test.PresentationLayer.Controllers;

public class ConfirmMailController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private AppUser _appUser;
    public ConfirmMailController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> IndexAsync(int Id)
    {
        await GetUser();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
    {
        await GetUser();
        if (_appUser.ConfirmCode == confirmMailViewModel.ConfirmCode)
        {
            _appUser.EmailConfirmed = true;
            await _userManager.UpdateAsync(_appUser);
            return RedirectToAction("Index","Login");
        }
        return View();
    }

    private async Task GetUser()
    {
        _appUser = await _userManager.GetUserAsync(HttpContext.User);
        if (_appUser != null)
        {
            ViewBag.Id = _appUser.Id;
            ViewBag.Name = _appUser.Name;
            ViewBag.Surname = _appUser.Surname;
            ViewBag.Email = _appUser.Email;
            ViewBag.City = _appUser.City;
            ViewBag.District = _appUser.District;
            ViewBag.UserName = _appUser.UserName;
            ViewBag.ImageUrl = _appUser.ImageUrl;
            ViewBag.ConfirmCode = _appUser.ConfirmCode;
        }
    }
}
