﻿using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Authentication;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using Test.PresentationLayer.Models.AppUser;

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
        RegisterViewModel viewModel = LoadViewModel(createAppUserRequest);

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
            var response = await _appUserDto.AddAsync(createAppUserRequest);

            var user = await _userManager.FindByEmailAsync(createAppUserRequest.Email);
            await _signInManager.SignInAsync(user, isPersistent: false);
            _userImageDto.AddUserFirstImages();

            return RedirectToAction("Index", "ConfirmMail");
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

    private RegisterViewModel LoadViewModel(CreateAppUserRequest createAppUserRequest)
    {
        var images = _universeImageDto.GetFirstUserImages();
        var viewModel = new RegisterViewModel
        {
            CreateAppUserRequest = createAppUserRequest,
            Images = images.ToList()
        };
        return viewModel;
    }
}
