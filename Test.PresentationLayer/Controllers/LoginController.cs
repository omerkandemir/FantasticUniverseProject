using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.MailOperations.MailKit;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Responses.UniverseImage;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly IUniverseImageDto _universeImageDto;

    public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IUniverseImageDto universeImageDto)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _universeImageDto = universeImageDto;
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
                var universeImage = _universeImageDto.Get(user.UniverseImageId) as GetAllUniverseImageResponse;
                byte[] imageURL = universeImage.ImageURL;
                HttpContext.Session.SetString("UserName", user.UserName);
                HttpContext.Session.Set("ImageURL", imageURL);
                return RedirectToAction("Index", "MainPage");
            }
            else
            {
                // Mail adresi onaylanmamışsa
                int code = SendMail.GenerateConfirmCode();
                SendMail.SendConfirmCodeMail(code, user);
                user.ConfirmCode = code;
                _userManager.UpdateAsync(user);
                ViewBag.Email = user.Email;
                return RedirectToAction("Index", "ConfirmMail");
            }
        }
        else
        {
            // Kullanıcı adı veya şifre hatalıysa
            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
        }
        return View(loginViewModel);
    }
}
