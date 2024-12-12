using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Concrete.UniverseImage;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

public class RegisterController : BaseController
{
    private readonly IHttpClientFactory _httpClientFactory;
    public RegisterController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var requestBody = new CreateAppUserRequest();
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync("/api/UniverseImages/PrepareUserForRegister");
        var imageResponse = await response.Content.ReadFromJsonAsync<List<GetUniverseImageResponse>>();
        var viewModel = new RegisterViewModel
        {
            CreateAppUserRequest = requestBody,
            Images = imageResponse,
        };
        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateAppUserRequest createAppUserRequest)
    {
        var viewModel = await LoadViewModel(createAppUserRequest);

        if (!ModelState.IsValid)
        {
            return View(new RegisterViewModel { CreateAppUserRequest = createAppUserRequest });
        }

        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PostAsJsonAsync("/api/AppUser/Register", createAppUserRequest);
        if (response.IsSuccessStatusCode)
        {
            var responseData = await response.Content.ReadFromJsonAsync<SuccessResponse<AppUser>>();
            if (responseData != null)
            {
                HttpContext.Session.SetInt32("Id", responseData.Entity.Id);
                HttpContext.Session.SetString("Email", createAppUserRequest.Email);
            }
            return RedirectToAction("Index", "ConfirmMail");
        }

        await AddErrorsToModelStateAsync(response);
        return View(new RegisterViewModel { CreateAppUserRequest = createAppUserRequest });
    }

    private async Task<RegisterViewModel> LoadViewModel(CreateAppUserRequest createAppUserRequest)
    {
        var requestBody = new CreateAppUserRequest();
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync("/api/UniverseImages/PrepareUserForRegister");

        var imageResponse = await response.Content.ReadFromJsonAsync<List<UniverseImage>>();
        var imageList = imageResponse;

        var viewModel = new RegisterViewModel
        {
            CreateAppUserRequest = createAppUserRequest,
        };

        return viewModel;
    }
}

