using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Concrete.UniverseImage;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

[Authorize]
public class MyProfileController : BaseController
{
    private readonly IHttpClientFactory _httpClientFactory;
    public MyProfileController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    #region UserInfos
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var username = User.Identity.Name;
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync($"/api/AppUser/GetUserByName/{username}");

        if (response.IsSuccessStatusCode)
        {
            var userResponse = JsonConvert.DeserializeObject<SuccessResponse<AppUser>>(await response.Content.ReadAsStringAsync());
            var model = new UpdateAppUserRequest
            {
                Id = userResponse.Entity.Id,
                Name = userResponse.Entity.Name,
                Surname = userResponse.Entity.Surname,
                City = userResponse.Entity.City,
                District = userResponse.Entity.District,
                UserName = userResponse.Entity.UserName
            };
            return View(model);
        }

        ModelState.AddModelError(string.Empty, "Kullanıcı bilgileri yüklenemedi.");
        return View(new UpdateAppUserRequest());
    }

    [HttpPost]
    public async Task<IActionResult> Index(UpdateAppUserRequest updateAppUserRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(updateAppUserRequest);
        }
        updateAppUserRequest.Id = GetCurrentUserId();
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PutAsJsonAsync("/api/AppUser/UpdateUser", updateAppUserRequest);

        if (response.IsSuccessStatusCode)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            var successResponse = JsonConvert.DeserializeObject<dynamic>(responseContent);

            HttpContext.Session.SetString("UserName", updateAppUserRequest.UserName);
            ViewBag.SuccessMessage = successResponse.message;

            return View(updateAppUserRequest);
        }
        await AddErrorsToModelStateAsync(response);

        return View(updateAppUserRequest);
    }
    #endregion

    #region UserEmail
    [HttpGet]
    public async Task<IActionResult> ChangeEmail()
    {
        var username = User.Identity.Name;
        var client = _httpClientFactory.CreateClient("APIClient");

        var response = await client.GetAsync($"/api/AppUser/GetUserByName/{username}");
        if (response.IsSuccessStatusCode)
        {
            var userResponse = JsonConvert.DeserializeObject<SuccessResponse<AppUser>>(await response.Content.ReadAsStringAsync());
            var model = new UpdateAppUserEmailRequest
            {
                Email = userResponse.Entity.Email
            };
            return View(model);
        }

        await AddErrorsToModelStateAsync(response);
        return View(new UpdateAppUserEmailRequest());
    }

    [HttpPost]
    public async Task<IActionResult> ChangeEmail(UpdateAppUserEmailRequest updateAppUserRequest)
    {
        updateAppUserRequest.Id = GetCurrentUserId();
        if (!ModelState.IsValid)
        {
            return View(updateAppUserRequest);
        }

        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PutAsJsonAsync("/api/AppUser/UpdateUserEmail", updateAppUserRequest);


        if (response.IsSuccessStatusCode)
        {
            HttpContext.Session.SetString("Email", updateAppUserRequest.Email);
            return RedirectToAction("Index", "ConfirmMail");
        }
        await AddErrorsToModelStateAsync(response);

        return View(updateAppUserRequest);
    }
    #endregion

    #region UserPassword
    [HttpGet]
    public async Task<IActionResult> ChangePassword()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ChangePassword(UpdateAppUserPasswordRequest updateAppUserPasswordRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(updateAppUserPasswordRequest);
        }

        var client = _httpClientFactory.CreateClient("APIClient");

        var username = User.Identity.Name;
        var userResponse = await client.GetAsync($"/api/AppUser/GetUserByName/{username}");

        if (userResponse.IsSuccessStatusCode)
        {
            var userData = JsonConvert.DeserializeObject<SuccessResponse<AppUser>>(await userResponse.Content.ReadAsStringAsync());
            updateAppUserPasswordRequest.Id = GetCurrentUserId();

            var response = await client.PutAsJsonAsync("/api/AppUser/UpdatePassword", updateAppUserPasswordRequest);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.SuccessMessage = "Şifre başarıyla güncellendi.";
                return View(new UpdateAppUserPasswordRequest());
            }

            await AddErrorsToModelStateAsync(response);
        }
        else
        {
            await AddErrorsToModelStateAsync(userResponse);
        }

        return View(updateAppUserPasswordRequest);
    }
    #endregion

    #region UserProfile
    [HttpGet]
    public async Task<IActionResult> ChangeProfileImage()
    {

        var username = User.Identity.Name;

        var profileData = await GetProfileImageDataAsync(username);

        if (profileData == null)
        {
            ModelState.AddModelError(string.Empty, "Profil verileri alınamadı.");
            return View(new ChangeProfileImageViewModel());
        }
        ViewBag.SuccessMessage = TempData["SuccessProfileImageMessage"];
        return View(profileData);
    }
    [HttpPost]
    public async Task<IActionResult> ChangeProfileImage(ChangeProfileImageViewModel profileImageViewModel)
    {

        if (!ModelState.IsValid)
        {
            await PrepareChangeProfileImageViewModel(profileImageViewModel);
            return View(profileImageViewModel);
        }

        var client = _httpClientFactory.CreateClient("APIClient");

        var updateRequest = new UpdateAppUserProfileImageRequest
        {
            Id = GetCurrentUserId(),
            SelectedImageId = profileImageViewModel.SelectedImageId
        };

        var response = await client.PutAsJsonAsync("/api/AppUser/UpdateProfileImage", updateRequest);
        if (response.IsSuccessStatusCode)
        {
            var sessionClient = _httpClientFactory.CreateClient("APIClient");
            var imageResponse = await sessionClient.GetAsync($"/api/UniverseImages/GetUserCurrentProfileImage/{profileImageViewModel.SelectedImageId}");
            if (imageResponse.IsSuccessStatusCode)
            {
                ViewBag.SuccessMessage = "Profil resmi başarıyla güncellendi.";
                var imageUrl = JsonConvert.DeserializeObject<GetUniverseImageResponse>(await imageResponse.Content.ReadAsStringAsync()).ImageURL;
                HttpContext.Session.Set("ImageURL", imageUrl);
            }

            TempData["SuccessProfileImageMessage"] = "Profil resmi başarıyla güncellendi.";
            return RedirectToAction(nameof(ChangeProfileImage));
        }

        await AddErrorsToModelStateAsync(response);
        var fallbackData = await GetProfileImageDataAsync(User.Identity.Name);
        profileImageViewModel.GetAllUniverseImageResponses = fallbackData.GetAllUniverseImageResponses;
        profileImageViewModel.CurrentImageBase64 = fallbackData.CurrentImageBase64;
        await PrepareChangeProfileImageViewModel(profileImageViewModel);
        return View(profileImageViewModel);
    }
    private async Task PrepareChangeProfileImageViewModel(ChangeProfileImageViewModel profileImageViewModel)
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync("/api/UserImage/GetAll");

        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var allImagesResponse = JsonConvert.DeserializeObject<GetAllUniverseImageResponse>(jsonResponse);

            if (allImagesResponse?.Responses != null && allImagesResponse.Responses.Any())
            {
                profileImageViewModel.GetAllUniverseImageResponses = allImagesResponse.Responses
                    .Select(image => new GetUniverseImageResponse
                    {
                        Id = image.Id,
                        ImageURL = image.ImageURL
                    }).ToList();
            }
        }
    }
    private async Task<ChangeProfileImageViewModel> GetProfileImageDataAsync(string username)
    {
        var client = _httpClientFactory.CreateClient("APIClient");

        var response = await client.GetAsync($"/api/UserImages/GetAllUsersProfileImages/{username}");
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var dynamicData = JsonConvert.DeserializeObject<ChangeProfileImageViewModel>(jsonResponse);

            if (dynamicData?.GetAllUniverseImageResponses == null || !dynamicData.GetAllUniverseImageResponses.Any())
            {
                ModelState.AddModelError(string.Empty, "Profil resimleri yüklenemedi.");
                return new ChangeProfileImageViewModel(); 
            }

            var currentImage = dynamicData.GetAllUniverseImageResponses.FirstOrDefault(x => x.Id == dynamicData.SelectedImageId);
            dynamicData.CurrentImageBase64 = currentImage != null ? Convert.ToBase64String(currentImage.ImageURL) : null;

            return dynamicData;
        }
        return null;
    }
    #endregion

    #region Logout
    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PostAsync("/api/AppUser/Logout", null);

        if (response.IsSuccessStatusCode)
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        TempData["ErrorMessage"] = "Çıkış işlemi başarısız oldu!";
        return View();
    }
    #endregion
}
