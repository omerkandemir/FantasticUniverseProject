using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Authentication;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;

namespace Test.PresentationLayer.Controllers;

public class RegisterController : Controller
{
    private readonly IAppUserDto _appUserDto;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public RegisterController(IAppUserDto appUserDto, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _appUserDto = appUserDto;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateAppUserRequest createAppUserRequest)
    {
        var response = await _appUserDto.AddAsync(createAppUserRequest);
       
        if (response.Success)
        {
            var user = await _userManager.FindByEmailAsync(createAppUserRequest.Email);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "ConfirmMail");
        }
        else
        {
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
        }
        return View();
    }
}
