using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Authentication;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using Test.PresentationLayer.Models;

namespace Test.PresentationLayer.Controllers;

public class RegisterController : Controller
{
    private readonly IAppUserDto _appUserDto;
    private readonly IUniverseImageDto _universeImageDto;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IUserImageDto _userImageDto;

    public RegisterController(
        IAppUserDto appUserDto,
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IUniverseImageDto universeImageDto,
        IUserImageDto userImageDto)
    {
        _appUserDto = appUserDto;
        _userManager = userManager;
        _signInManager = signInManager;
        _universeImageDto = universeImageDto;
        _userImageDto = userImageDto;
    }

    [HttpGet]
    public IActionResult Index()
    {
        _universeImageDto.AddFirstUserDatas();
        var images = _universeImageDto.GetFirstUserImages();
        var viewModel = new RegisterViewModel
        {
            CreateAppUserRequest = new CreateAppUserRequest(),
            Images = images.ToList()
        };
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateAppUserRequest createAppUserRequest)
    {
        var response = await _appUserDto.AddAsync(createAppUserRequest);

        if (response.Success)
        {
            var user = await _userManager.FindByEmailAsync(createAppUserRequest.Email);
            await _signInManager.SignInAsync(user, isPersistent: false);
            _userImageDto.AddUserFirstImages();

            return RedirectToAction("Index", "ConfirmMail");
        }
        else
        {
            ModelState.AddModelError(string.Empty, response.ErrorMessage);
        }
        var images = _universeImageDto.GetFirstUserImages();
        var viewModel = new RegisterViewModel
        {
            CreateAppUserRequest = createAppUserRequest,
            Images = images.ToList()
        };

        viewModel.Images = _universeImageDto.GetFirstUserImages().ToList();

        return View(viewModel);
    }
}
