using Microsoft.AspNetCore.Mvc;
using NLayer.Mapper.Requests.Universe;
using NLayer.Mapper.Responses.Concrete.Universe;
using System.Text.Json;

namespace Test.PresentationLayer.Controllers;

public class UniverseController : BaseController
{
    private readonly IHttpClientFactory _httpClientFactory;
    public UniverseController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }


    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateUniverseRequest createUniverseRequest)
    {
        if (!string.IsNullOrEmpty(createUniverseRequest.GalaxiesJson))
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true  // Küçük/büyük harf duyarlılığını kapatır
            };

            createUniverseRequest.Galaxies = JsonSerializer.Deserialize<List<NLayer.Entities.Concretes.Galaxy>>(createUniverseRequest.GalaxiesJson, options);
        }

        if (!ModelState.IsValid)
            return View(createUniverseRequest);

        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PostAsJsonAsync("/api/Universes/CreateUniverseAsync", createUniverseRequest);
        if (response.IsSuccessStatusCode)
        {
            ViewBag.SuccessMessage = "Evren başarıyla oluşturuldu.";
            return RedirectToAction("Index");
        }
        await AddErrorsToModelStateAsync(response);
        return View(createUniverseRequest);
    }


    [HttpGet]
    public async Task<IActionResult> MyUniverses()
    {
        int userId = GetCurrentUserId();

        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync($"/api/Universes/GetUserUniverses/{userId}");

        if (response.IsSuccessStatusCode)
        {
            var universeList = await response.Content.ReadFromJsonAsync<List<GetUniverseResponse>>();

            return View(universeList);
        }
        await AddErrorsToModelStateAsync(response);
        return View(new List<GetUniverseResponse>());
    }

    [HttpGet]
    public async Task<IActionResult> Detail()
    {
        int id = GetCurrentUserId();
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync($"/api/Universes/GetUniverseDetails/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return NotFound();
        }

        var universe = await response.Content.ReadFromJsonAsync<GetUniverseResponse>();
        return Json(universe);

    }
}
