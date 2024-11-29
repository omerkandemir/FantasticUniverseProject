using Microsoft.AspNetCore.Mvc;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AppUser;
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
        var viewModel = await LoadViewModel(new CreateAppUserRequest());
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

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Resimler yüklenemedi.");
            return new RegisterViewModel(); 
        }

        var imageResponse = await response.Content.ReadFromJsonAsync<List<UniverseImage>>();
        var imageList = imageResponse;

        var viewModel = new RegisterViewModel
        {
            CreateAppUserRequest = createAppUserRequest,
            Images = imageList
        };

        return viewModel;
    }
}

