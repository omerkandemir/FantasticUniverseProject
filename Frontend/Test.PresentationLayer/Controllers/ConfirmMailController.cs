using Microsoft.AspNetCore.Mvc;
using NLayer.Mapper.Requests.AppUser;
using Test.PresentationLayer.Models.AppUser;

namespace Test.PresentationLayer.Controllers;

public class ConfirmMailController : BaseController
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ConfirmMailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = new ConfirmMailViewModel
        {
            Mail = HttpContext.Session.GetString("Email"),
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
    {
        ConfirmMailRequest confirmMailRequest = new ConfirmMailRequest()
        {
            Id = GetCurrentUserId(),
            ConfirmCode = confirmMailViewModel.ConfirmCode
        };

        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PostAsJsonAsync("/api/AppUser/ConfirmMail", confirmMailRequest);

        if (response.IsSuccessStatusCode)
        {
            // Eğer doğrulama başarılıysa, Login sayfasına yönlendir
            return RedirectToAction("Index", "Login");
        }

        await AddErrorsToModelStateAsync(response);

        return View(confirmMailViewModel); 
    }
}
