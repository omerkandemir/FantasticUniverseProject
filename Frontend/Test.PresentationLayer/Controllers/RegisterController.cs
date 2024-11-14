using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

public class RegisterController : Controller
{
    private readonly IAppUserDto _appUserDto;
    private readonly ISignInService<AppUser> _signInService;
    private readonly IUniverseImageDto _universeImageDto;
    private readonly IUserImageDto _userImageDto;

    public RegisterController(
        IAppUserDto appUserDto,
        ISignInService<AppUser> signInService,
        IUniverseImageDto universeImageDto,
        IUserImageDto userImageDto)
    {
        _appUserDto = appUserDto;
        _signInService = signInService;
        _universeImageDto = universeImageDto;
        _userImageDto = userImageDto;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        await _universeImageDto.AddFirstUserDatas();
        var images = await _universeImageDto.GetFirstUserImages();
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
        RegisterViewModel viewModel = await LoadViewModel(createAppUserRequest);

        if (createAppUserRequest.Password != createAppUserRequest.ConfirmPassword)
        {
            ModelState.AddModelError(string.Empty, "Parolalar eşleşmiyor.");
        }

        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }
        try
        {
            var result = await _appUserDto.AddAsync(createAppUserRequest);
            var userResult = await _appUserDto.GetUserByMailAsync(createAppUserRequest.Email);
            if (userResult.Success)
            {
                var user = userResult as SuccessResponse<AppUser>;

                await _signInService.SignInAsync(user.Entity, isPersistent: false);
                _userImageDto.AddUserFirstImages();

                return RedirectToAction("Index", "ConfirmMail");
            }
            else
            {
                var errorResponse = result as IErrorResponse;
                if (errorResponse != null)
                {
                    ModelState.AddModelError(string.Empty, errorResponse.ErrorMessage);
                }
                return NotFound();
            }
        }
        catch (ValidationException ex)
        {
            foreach (var error in ex.Errors)
            {
                ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Bir hata oluştu: " + ex.Message);
        }
        return View(viewModel);
    }

    private async Task<RegisterViewModel> LoadViewModel(CreateAppUserRequest createAppUserRequest)
    {
        var images = await _universeImageDto.GetFirstUserImages();
        var viewModel = new RegisterViewModel
        {
            CreateAppUserRequest = createAppUserRequest,
            Images = images.ToList()
        };
        return viewModel;
    }
}
