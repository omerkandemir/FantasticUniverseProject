using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.UniverseImage;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

[Authorize]
public class MyProfileController : Controller
{
    private readonly IUserImageDto _userImageDto;
    private readonly IUniverseImageDto _universeImageDto;
    private readonly IAppUserDto _appUserDto;
    private readonly ISignInService<AppUser> _signInService;

    public MyProfileController(IUserImageDto userImageDto, IUniverseImageDto universeImageDto, IAppUserDto appUserDto, ISignInService<AppUser> signInService)
    {
        _userImageDto = userImageDto;
        _universeImageDto = universeImageDto;
        _appUserDto = appUserDto;
        _signInService = signInService;
    }
    #region UserInfos
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _appUserDto.GetUserByNameAsync(User.Identity.Name) as SuccessResponse<AppUser>;

        UpdateAppUserRequest updateAppUserRequest = new UpdateAppUserRequest()
        {
            Id = values.Entity.Id,
            Name = values.Entity.Name,
            Surname = values.Entity.Surname,
            City = values.Entity.City,
            District = values.Entity.District,
            UserName = values.Entity.UserName,
        };
        return View(updateAppUserRequest);
    }

    [HttpPost]
    public async Task<IActionResult> Index(UpdateAppUserRequest updateAppUserRequest)
    {
        try
        {
            // Model geçerli değilse, hata mesajlarını göster
            if (!ModelState.IsValid)
            {
                return View(updateAppUserRequest);
            }
            var userResponse = await _appUserDto.GetUserByNameAsync(User.Identity.Name);
            if (userResponse.Success)
            {
                var user = userResponse as SuccessResponse<AppUser>;
                //Güncellendiğinde Kullanıcı bilgilerinin güncel olması için
                user.Entity.Name = updateAppUserRequest.Name;
                user.Entity.Surname = updateAppUserRequest.Surname;
                user.Entity.City = updateAppUserRequest.City;
                user.Entity.District = updateAppUserRequest.District;
                user.Entity.UserName = updateAppUserRequest.UserName;

                //Güncelllenecek nesnenin Id si
                updateAppUserRequest.Id = user.Entity.Id;

                var result = await _appUserDto.UpdateAsync(updateAppUserRequest);
                if (result.Success)
                {
                    await _signInService.RefreshSignInAsync(user.Entity); // oturumu yenile
                    HttpContext.Session.SetString("UserName", updateAppUserRequest.UserName);
                    ViewBag.SuccessMessage = "Kullanıcı Bilgileri Başarıyla Güncellendi";
                    return View(updateAppUserRequest);
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
            else
            {
                ErrorMessage(userResponse);
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
        return View(updateAppUserRequest);
    }

    
    #endregion

    #region UserEmail
    [HttpGet]
    public async Task<IActionResult> ChangeEmail()
    {
        var user = await _appUserDto.GetUserByNameAsync(User.Identity.Name) as SuccessResponse<AppUser>;

        UpdateAppUserEmailRequest updateAppUserEmailRequest = new UpdateAppUserEmailRequest()
        {
            Email = user.Entity.Email,
        };
        return View(updateAppUserEmailRequest);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeEmail(UpdateAppUserEmailRequest updateAppUserRequest)
    {
        try
        {
            var userResponse = await _appUserDto.GetUserByNameAsync(User.Identity.Name);

            if (userResponse.Success)
            {
                var user = userResponse as SuccessResponse<AppUser>;

                updateAppUserRequest.Id = user.Entity.Id;

                var result = await _appUserDto.UpdateEmailAsync(updateAppUserRequest);
                if (result.Success)
                {
                    return RedirectToAction("Index", "ConfirmMail");
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
            else
            {
                ErrorMessage(userResponse);
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
        
        return View(updateAppUserRequest);
    }
    #endregion

    #region UserPassword
    [HttpGet]
    public async Task<IActionResult> ChangePassword()
    {
        await _appUserDto.GetUserByNameAsync(User.Identity.Name);

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ChangePassword(UpdateAppUserPasswordRequest updateAppUserPasswordRequest)
    {
        try
        {
            var userResult = await _appUserDto.GetUserByNameAsync(User.Identity.Name);
            if (userResult.Success)
            {
                var user = userResult as SuccessResponse<AppUser>;
                updateAppUserPasswordRequest.Id = user.Entity.Id;
                var result = await _appUserDto.UpdatePasswordAsync(updateAppUserPasswordRequest);
                if (result.Success)
                {
                    ViewBag.SuccessMessage = "Şifre başarıyla güncellendi.";
                }
            }
            else
            {
                ErrorMessage(userResult);
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
        return View(updateAppUserPasswordRequest);
    }
    #endregion

    #region UserProfile
    [HttpGet]
    public async Task<IActionResult> ChangeProfileImage()
    {
        var userResponse = await _appUserDto.GetUserByNameAsync(User.Identity.Name) as SuccessResponse<AppUser>;

        ChangeProfileImageViewModel profileImageViewModel = new ChangeProfileImageViewModel()
        {
            SelectedImageId = userResponse.Entity.UniverseImageId,
            GetAllUniverseImageResponses = _userImageDto.GetUsersImage()
        };
        return View(profileImageViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> ChangeProfileImage(ChangeProfileImageViewModel profileImageViewModel)
    {
        try
        {
            var userResponse = await _appUserDto.GetUserByNameAsync(User.Identity.Name);
            if (userResponse.Success)
            {
                var user = userResponse as SuccessResponse<AppUser>;
                if (ModelState.IsValid)
                {
                    if (profileImageViewModel.SelectedImageId == user.Entity.UniverseImageId)
                    {
                        ModelState.Clear(); // ModelState'i temizle
                        ModelState.AddModelError(string.Empty, "Seçtiğiniz profil resmi zaten mevcut profil resminizle aynı!");
                        PrepareChangeProfileImageViewModelForView(profileImageViewModel);
                        return View(profileImageViewModel);
                    }
                    else
                    {
                        UpdateAppUserProfileImageRequest updateAppUserProfileImageRequest = new UpdateAppUserProfileImageRequest()
                        {
                            SelectedImageId = profileImageViewModel.SelectedImageId,
                            Id = user.Entity.Id
                        };
                        var result = await _appUserDto.UpdateProfilePhotoAsync(updateAppUserProfileImageRequest);
                        if (result.Success)
                        {
                            await _signInService.RefreshSignInAsync(user.Entity);
                            var newUniverseImage = _universeImageDto.Get(profileImageViewModel.SelectedImageId) as GetAllUniverseImageResponse;
                            if (newUniverseImage != null)
                            {
                                HttpContext.Session.Set("ImageURL", newUniverseImage.ImageURL);
                            }
                            return RedirectToAction("Index", "MainPage");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Profil Resmi Değiştirilemedi");
                    PrepareChangeProfileImageViewModelForView(profileImageViewModel);
                }
            }
            else
            {
                ErrorMessage(userResponse);
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
        
        return View(profileImageViewModel);
    }
    #endregion

    #region Logout
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInService.SignOutAsync();
        HttpContext.Session.Clear(); // Oturum bilgilerini temizler
        return RedirectToAction("Index", "Login");
    }
    #endregion


    private void ErrorMessage(IResponse response)
    {
        var errorResponse = response as IErrorResponse;
        if (errorResponse != null)
        {
            ModelState.AddModelError(string.Empty, errorResponse.ErrorMessage);
        }
    }
    private void PrepareChangeProfileImageViewModelForView(ChangeProfileImageViewModel profileImageViewModel)
    {
        profileImageViewModel.GetAllUniverseImageResponses = _userImageDto.GetUsersImage();
    }
}
