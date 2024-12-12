using AdminSphere.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminSphere.Controllers;

public class AdminBaseController : Controller
{
    protected int GetCurrentUserId()
    {
        var userId = HttpContext.Session.GetInt32("Id");
        return userId.Value;
    }

    /// <summary>
    /// API'den gelen hataları ModelState'e ekler.
    /// </summary>
    /// <param name="response">HttpResponseMessage</param>
    /// <returns></returns>
    protected async Task AddErrorsToModelStateAsync(HttpResponseMessage response)
    {
        if (response.Content == null) return;

        var errorResponse = await response.Content.ReadAsStringAsync();
        var errorData = JsonConvert.DeserializeObject<ErrorResponse>(errorResponse);

        if (errorData?.Errors != null && errorData?.Errors.Count != 0)
        {
            foreach (var error in errorData.Errors)
            {
                // Hata mesajını tekrar eklememek için kontrol
                if (!ModelState.ContainsKey(error.PropertyName))
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
        else if (!string.IsNullOrEmpty(errorData?.ErrorMessage))
        {
            // Genel hata mesajını tekrar eklememek için kontrol
            if (!ModelState.Values.Any(v => v.Errors.Any(e => e.ErrorMessage == errorData.ErrorMessage)))
            {
                ModelState.AddModelError(string.Empty, errorData.ErrorMessage);
            }
        }
        else if (!string.IsNullOrEmpty(errorData?.Message))
        {
            if (!ModelState.Values.Any(v => v.Errors.Any(e => e.ErrorMessage == errorData.Message)))
            {
                ModelState.AddModelError(string.Empty, errorData.Message);
            }
        }
        else
        {
            ModelState.AddModelError(string.Empty, errorData?.Message ?? "Bilinmeyen bir hata oluştu.");
        }
    }
}
