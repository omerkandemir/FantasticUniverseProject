using Microsoft.AspNetCore.Mvc;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;

namespace Test.PresentationLayer.Controllers;

public class RegisterController : Controller
{
    private readonly IAppUserDto _appUserDto;

    public RegisterController(IAppUserDto appUserDto)

    {
        _appUserDto = appUserDto;
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
            return RedirectToAction("Index", "ConfirmMail");
        }
        else
        {
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
        }
        return View();
    }
}
