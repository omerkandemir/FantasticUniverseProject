using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

public class ConfirmMailController : Controller
{
    private readonly IAppUserDto _appUserDto;
    private AppUser _appUser;
    public ConfirmMailController(IAppUserDto appUserDto)
    {
        _appUserDto = appUserDto;
    }

    [HttpGet]
    public async Task<IActionResult> IndexAsync()
    {
        await GetUser();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
    {
        await GetUser();
        ConfirmMailRequest confirmMailRequest = new ConfirmMailRequest()
        {
            Id = _appUser.Id,
            ConfirmCode = confirmMailViewModel.ConfirmCode
        };
        if (_appUser.ConfirmCode == confirmMailViewModel.ConfirmCode)
        {
            await _appUserDto.ConfirmMailAsync(confirmMailRequest);
            return RedirectToAction("Index", "Login");
        }
        return View();
    }

    private async Task GetUser()
    {
        var result = await _appUserDto.GetUserAsync(HttpContext.User);
        if (result.Success)
        {
            var user = result as SuccessResponse<AppUser>;
            _appUser = user.Entity;

            FillViewBag();
        }
        else
        {
            var errorResponse = result as IErrorResponse;
            if (errorResponse != null)
            {
                ModelState.AddModelError(string.Empty, errorResponse.ErrorMessage);
            }
        }
    }

    private void FillViewBag()
    {
        ViewBag.Id = _appUser.Id;
        ViewBag.Name = _appUser.Name;
        ViewBag.Surname = _appUser.Surname;
        ViewBag.Email = _appUser.Email;
        ViewBag.City = _appUser.City;
        ViewBag.District = _appUser.District;
        ViewBag.UserName = _appUser.UserName;
        ViewBag.UniverseImageId = _appUser.UniverseImageId;
        ViewBag.ConfirmCode = _appUser.ConfirmCode;
    }
}
