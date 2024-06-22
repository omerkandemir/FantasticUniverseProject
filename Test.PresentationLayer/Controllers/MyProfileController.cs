using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Authentication;
using NLayer.Mapper.Requests.AppUser;

namespace Test.PresentationLayer.Controllers;

[Authorize]
public class MyProfileController : Controller
{
    public readonly UserManager<AppUser> _userManager;

    public MyProfileController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        UpdateAppUserRequest updateAppUserRequest = new UpdateAppUserRequest()
        {
            Name = values.Name,
            Surname = values.Surname,
            Email = values.Email,
            City = values.City,
            District = values.District,
            Username = values.UserName,
            UniverseImageId = values.UniverseImageId,
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
        
        user.Name = updateAppUserRequest.Name;
        user.Surname = updateAppUserRequest.Surname;
        user.Email = updateAppUserRequest.Email;
        user.City = updateAppUserRequest.City;
        user.District = updateAppUserRequest.District;
        user.UserName = updateAppUserRequest.Username;
        user.UniverseImageId = updateAppUserRequest.UniverseImageId;
       var result = await _userManager.UpdateAsync(user);   
        if (result.Succeeded)
        {
            ViewBag.SuccessMessage = "Kullanıcı Bilgileri Başarıyla Güncellendi";
            return View(updateAppUserRequest);
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View(updateAppUserRequest);
    }
}
