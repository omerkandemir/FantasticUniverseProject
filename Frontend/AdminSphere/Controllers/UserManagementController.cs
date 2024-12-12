using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Entities.Authorization;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Concrete.AppRole;
using NLayer.Mapper.Responses.Concrete.AppUser;

namespace AdminSphere.Controllers;

public class UserManagementController : AdminBaseController
{
    private readonly IHttpClientFactory _httpClientFactory;
    public UserManagementController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync($"/api/AppUser/GetAllAsync");

        if (response.IsSuccessStatusCode)
        {
            var userResponse = JsonConvert.DeserializeObject<SuccessListResponse<GetAppUserResponse>>(await response.Content.ReadAsStringAsync());

            return View(userResponse.Responses);
        }

        ModelState.AddModelError(string.Empty, "Kullanıcılar getirilemedi.");
        return View();
    }
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.GetAsync($"/api/AppUser/GetByIdAsync/{id}");

        if (response.IsSuccessStatusCode)
        {
            var user = JsonConvert.DeserializeObject<GetAppUserResponse>(await response.Content.ReadAsStringAsync());
            return View(user);
        }

        ModelState.AddModelError(string.Empty, "Kullanıcı bilgileri getirilemedi.");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AppUser user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PutAsJsonAsync($"/api/AppUser/UpdateUser", user);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        ModelState.AddModelError(string.Empty, "Kullanıcı bilgileri güncellenemedi.");
        return View(user);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.DeleteAsync($"/api/AppUser/DeleteAsync/{id}");

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }

        ModelState.AddModelError(string.Empty, "Kullanıcı silinemedi.");
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> AssignRole(int id)
    {
        var client = _httpClientFactory.CreateClient("APIClient");
        var userResponse = await client.GetAsync($"/api/AppUser/GetByIdAsync/{id}");
        //Tüm rolleri getir.
        var roleResponse = await client.GetAsync($"/api/AppRole/GetAllRolesAsync");
        // Kullanıcının rollerini getir
        var userRoleResponse = await client.GetAsync($"/api/AppUser/GetUserRolesByIdAsync/{id}");
        if (userResponse.IsSuccessStatusCode && roleResponse.IsSuccessStatusCode && userRoleResponse.IsSuccessStatusCode)
        {
            var user = JsonConvert.DeserializeObject<GetAppUserResponse>(await userResponse.Content.ReadAsStringAsync());
            
            var roles = JsonConvert.DeserializeObject<List<GetAppRoleResponse>>(await roleResponse.Content.ReadAsStringAsync());
            var userRoles = JsonConvert.DeserializeObject<List<string>>(await userRoleResponse.Content.ReadAsStringAsync());
            var model = roles.Select(role => new AssignRole
            {
                UserId = user.Id,
                Username = user.UserName,
                RoleId = role.Id,
                RoleName = role.Name,
                HasAssign = userRoles.Contains(role.Name) // Kullanıcının bu role sahip olup olmadığını kontrol et
            }).ToList();
            return View(model);
        }
        ModelState.AddModelError(string.Empty, "Kullanıcıya ait Roller getirilemedi.");
        return View();
    }
    [HttpPost]  
    public async Task<IActionResult> AssignRole(List<AssignRole> model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var client = _httpClientFactory.CreateClient("APIClient");
        var response = await client.PostAsJsonAsync($"/api/AppUser/UpdateUserRolesAsync", model);
        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("Index"); 
        }
        ModelState.AddModelError(string.Empty, "Kullanıcıya ait Roller Güncellenemedi!");
        return View();
    }
}
