using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AppRole;
using NLayer.Mapper.Requests.UniverseImage;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AppRole;
using NLayer.Mapper.Responses.Concrete.AppUser;
using NLayer.Mapper.Responses.Concrete.UniverseImage;
using System.Net.Http;
using System.Text;

namespace AdminSphere.Controllers;

public class DataManagementController : AdminBaseController
{
    private readonly IHttpClientFactory _httpClientFactory;
    public DataManagementController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> DefaultImages()
    {
        var client = _httpClientFactory.CreateClient("APIClient");

        var response = await client.GetAsync("/api/UniverseImages/GetDefaultImagesAsync");

        if (response.IsSuccessStatusCode)
        {
            var imageResponse = await response.Content.ReadFromJsonAsync<List<GetUniverseImageResponse>>();

            return View(imageResponse);
        }

        ModelState.AddModelError(string.Empty, "Görseller getirilemedi.");
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> DefaultImages(IFormFileCollection images)
    {
        var newImages = new List<CreateUniverseImageRequest>();
        foreach (var file in images)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var universeImage = new CreateUniverseImageRequest
            {
                UniverseId = 4,
                ImageURL = memoryStream.ToArray()
            };
            newImages.Add(universeImage);
        }
        var client = _httpClientFactory.CreateClient("APIClient");

        var response = await client.PostAsJsonAsync("/api/UniverseImages/AddDefaultImagesAsync", newImages);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("DefaultImages");
        }

        ModelState.AddModelError(string.Empty, "Görseller Eklenemedi!");
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteDefaultImages([FromBody] DeleteUniverseImageRequest request)
    {
        var client = _httpClientFactory.CreateClient("APIClient");

        var requestContent = new StringContent(
        JsonConvert.SerializeObject(request),
        Encoding.UTF8,
        "application/json"
    );
        var response = await client.PostAsync("api/UniverseImages/DeleteAsync", requestContent);

        if (!response.IsSuccessStatusCode)
        {
            await AddErrorsToModelStateAsync(response);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    
}
