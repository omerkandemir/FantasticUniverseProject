using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLayer.Mapper.Requests.AppRole;
using NLayer.Mapper.Responses.Concrete.AppRole;
using System.Text;

namespace AdminSphere.Controllers;

public class RolesController : AdminBaseController
{
    private readonly IHttpClientFactory _httpClientFactory;
    public RolesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync($"/api/AppRole/GetAllRolesAsync");

        if (response.IsSuccessStatusCode)
        {
            var rolesResponse = JsonConvert.DeserializeObject<List<GetAppRoleResponse>>(await response.Content.ReadAsStringAsync());

            return View(rolesResponse);
        }

        await AddErrorsToModelStateAsync(response);
        return View();
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateAppRoleRequest createAppRoleRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(createAppRoleRequest);
        }
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PostAsJsonAsync("/api/AppRole/AddRoleAsync", createAppRoleRequest);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        await AddErrorsToModelStateAsync(response);

        return View(createAppRoleRequest);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync($"/api/AppRole/GetRoleAsync/{id}");

        if (response.IsSuccessStatusCode)
        {
            var roleResponse = JsonConvert.DeserializeObject<GetAppRoleResponse>(await response.Content.ReadAsStringAsync());
            var model = new UpdateAppRoleRequest
            {
                Id = roleResponse.Id,
                Name = roleResponse.Name,
                IsActive = roleResponse.IsActive,
            };
            return View(model);
        }

        ModelState.AddModelError(string.Empty, "Rol bilgileri yüklenemedi.");
        return View(new UpdateAppRoleRequest());
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateAppRoleRequest updateAppRoleRequest)
    {
        if (!ModelState.IsValid)
        {
            return View(updateAppRoleRequest);
        }
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PutAsJsonAsync("/api/AppRole/UpdateRoleAsync", updateAppRoleRequest);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");

        }
        await AddErrorsToModelStateAsync(response);

        return View(updateAppRoleRequest);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync($"api/AppRole/GetRoleAsync/{id}");

        if (!response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        var roleResponse = JsonConvert.DeserializeObject<DeleteConfirmationAppRoleRequest>(await response.Content.ReadAsStringAsync());
        var model = new DeleteConfirmationAppRoleRequest
        {
            Id = roleResponse.Id,
            Name = roleResponse.Name,
            IsActive = roleResponse.IsActive,
            CreatedDate = roleResponse.CreatedDate,
        };
        return View(model); 
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(DeleteConfirmationAppRoleRequest deleteConfirmationAppRoleRequest)
    {

        var client = _httpClientFactory.CreateClient("APIClient");
        var requestContent = new StringContent(
        JsonConvert.SerializeObject(deleteConfirmationAppRoleRequest),
        Encoding.UTF8,
        "application/json"
    );
        var response = await client.PostAsync("api/AppRole/DeleteAsync", requestContent);

        if (!response.IsSuccessStatusCode)
        {
            await AddErrorsToModelStateAsync(response);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }
}
