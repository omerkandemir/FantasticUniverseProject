using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Responses.UniverseImage;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

public class LoginController : Controller
{
    private readonly IAppUserDto _appUserDto;
    private readonly ISignInService<AppUser> _signInService;
    private readonly IUniverseImageDto _universeImageDto;
    private readonly IAppUserService _appUserService;

    public LoginController(IUniverseImageDto universeImageDto, IAppUserDto appUserDto, ISignInService<AppUser> signInService, IAppUserService appUserService)
    {
        _universeImageDto = universeImageDto;
        _appUserDto = appUserDto;
        _signInService = signInService;
        _appUserService = appUserService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(LoginViewModel loginViewModel)
    {
        var result = await _signInService.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, true, true);
        if (result.Succeeded)
        {
            var userResult = await _appUserDto.GetUserAsync(HttpContext.User);
            if (userResult.Success)
            {
                var user = userResult as SuccessResponse<AppUser>;
                if (user.Entity.EmailConfirmed == true)
                {
                    return ConfimedMailProcess(user);
                }
                else
                {
                    // Mail adresi onaylanmamışsa
                    return NotConfirmedProcess(user);
                }
            }
            else
            {
                var errorResponse = userResult as IErrorResponse;
                if (errorResponse != null)
                {
                    ModelState.AddModelError(string.Empty, errorResponse.ErrorMessage);
                }
            }
        }
        else
        {
            // Kullanıcı adı veya şifre hatalıysa
            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
        }
        return View(loginViewModel);
    }

    private IActionResult NotConfirmedProcess(SuccessResponse<AppUser>? user)
    {
        _appUserService.GenerateCodeFromUser(user.Entity);

        ViewBag.Email = user.Entity.Email;
        return RedirectToAction("Index", "ConfirmMail");
    }

    private IActionResult ConfimedMailProcess(SuccessResponse<AppUser>? user)
    {
        var universeImage = _universeImageDto.Get(user.Entity.UniverseImageId) as GetAllUniverseImageResponse;
        byte[] imageURL = universeImage.ImageURL;
        HttpContext.Session.SetString("UserName", user.Entity.UserName);
        HttpContext.Session.Set("ImageURL", imageURL);
        return RedirectToAction("Index", "MainPage");
    }
}
