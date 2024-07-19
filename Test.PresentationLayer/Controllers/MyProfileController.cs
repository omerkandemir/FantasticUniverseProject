using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Utilities.MailOperations.MailKit;
using NLayer.Dto.Managers.Abstract;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.UniverseImage;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

[Authorize]
public class MyProfileController : Controller
{
    public readonly UserManager<AppUser> _userManager;
    private readonly IUserImageDto _userImageDto;
    private readonly IUniverseImageDto _universeImageDto;
    private readonly SignInManager<AppUser> _signInManager;

    public MyProfileController(UserManager<AppUser> userManager, IUserImageDto userImageDto, SignInManager<AppUser> signInManager, IUniverseImageDto universeImageDto)
    {
        _userManager = userManager;
        _userImageDto = userImageDto;
        _signInManager = signInManager;
        _universeImageDto = universeImageDto;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        UpdateAppUserRequest updateAppUserRequest = new UpdateAppUserRequest()
        {
            Id = values.Id,
            Name = values.Name,
            Surname = values.Surname,
            City = values.City,
            District = values.District,
            UserName = values.UserName,
        };
        return View(updateAppUserRequest);
    }
    [HttpPost]
    public async Task<IActionResult> Index(UpdateAppUserRequest updateAppUserRequest)
    {
        if (!ModelState.IsValid)
        {
            // Model geçerli değilse, hata mesajlarını göster
            return View(updateAppUserRequest);
        }
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user == null)
        {
            return NotFound("Kullanıcı bulunamadı.");
        }
        user.Name = updateAppUserRequest.Name;
        user.Surname = updateAppUserRequest.Surname;
        user.City = updateAppUserRequest.City;
        user.District = updateAppUserRequest.District;
        user.UserName = updateAppUserRequest.UserName;
        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            await _signInManager.RefreshSignInAsync(user); // oturumu yenile
            HttpContext.Session.SetString("UserName", updateAppUserRequest.UserName);
            ViewBag.SuccessMessage = "Kullanıcı Bilgileri Başarıyla Güncellendi";
            return View(updateAppUserRequest);
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(updateAppUserRequest);
    }


    [HttpGet]
    public async Task<IActionResult> ChangeEmail()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user == null)
        {
            return NotFound("Kullanıcı bulunamadı.");
        }
        ChangeEmailViewModel changeEmailViewModel = new ChangeEmailViewModel()
        {
            Email = user.Email,
        };
        return View(changeEmailViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeEmail(ChangeEmailViewModel changeEmailViewModel)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user == null)
        {
            return NotFound("Kullanıcı bulunamadı.");
        }

        var passwordCheck = await _userManager.CheckPasswordAsync(user, changeEmailViewModel.Password);
        if (!passwordCheck)
        {
            ModelState.AddModelError(string.Empty, "Eksik ya da Hatalı şifre girdiniz.");
            return View(changeEmailViewModel);
        }

        int code = SendMail.GenerateConfirmCode();

        user.EmailConfirmed = false;
        user.Email = changeEmailViewModel.Email;
        user.ConfirmCode = code;

        SendMail.SendConfirmCodeMail(code, user);

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "ConfirmMail");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(changeEmailViewModel);
    }


    [HttpGet]
    public async Task<IActionResult> ChangePassword()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user == null)
        {
            return NotFound("Kullanıcı bulunamadı.");
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user == null)
        {
            return NotFound("Kullanıcı bulunamadı.");
        }


        if (!await _userManager.CheckPasswordAsync(user, changePasswordViewModel.CurrentPassword))
        {
            ModelState.AddModelError(string.Empty, "Mevcut şifreniz yanlış.");
            return View(changePasswordViewModel);
        }
        else if (changePasswordViewModel.CurrentPassword == changePasswordViewModel.NewPassword)
        {
            ModelState.AddModelError(string.Empty, "Yeni şifre, mevcut şifre ile aynı olamaz.");
            return View(changePasswordViewModel);
        }
        else if (changePasswordViewModel.NewPassword != changePasswordViewModel.ConfirmNewPassword)
        {
            ModelState.AddModelError(string.Empty, "Şifre ve şifre tekrarı farklı olamaz.");
            return View(changePasswordViewModel);
        }

        var result = await _userManager.ChangePasswordAsync(user, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);
        if (result.Succeeded)
        {
            ViewBag.SuccessMessage = "Şifre başarıyla güncellendi.";
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(changePasswordViewModel);
    }


    private void PrepareChangeProfileImageViewModelForView(ChangeProfileImageViewModel profileImageViewModel)
    {
        profileImageViewModel.getAllUniverseImageResponses = _userImageDto.GetUsersImage();
    }

    [HttpGet]
    public async Task<IActionResult> ChangeProfileImage()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user == null)
        {
            return NotFound();
        }
        ChangeProfileImageViewModel profileImageViewModel = new ChangeProfileImageViewModel()
        {
            getAllUniverseImageResponses = _userImageDto.GetUsersImage(),
            SelectedImageId = user.UniverseImageId,
        };
        return View(profileImageViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> ChangeProfileImage(ChangeProfileImageViewModel profileImageViewModel)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        if (user == null)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            if (profileImageViewModel.SelectedImageId == user.UniverseImageId)
            {
                ModelState.Clear(); // ModelState'i temizle
                ModelState.AddModelError(string.Empty, "Seçtiğiniz profil resmi zaten mevcut profil resminizle aynı!");
                PrepareChangeProfileImageViewModelForView(profileImageViewModel);
                return View(profileImageViewModel);
            }
            else
            {
                user.UniverseImageId = profileImageViewModel.SelectedImageId;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(user);
                    var newUniverseImage = _universeImageDto.Get(profileImageViewModel.SelectedImageId) as GetAllUniverseImageResponse;
                    if (newUniverseImage != null)
                    {
                        //HttpContext.Session.Remove("ImageURL");
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
        return View(profileImageViewModel);
    }


    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        HttpContext.Session.Clear(); // Oturum bilgilerini temizler
        return RedirectToAction("Index", "Login");
    }
}
