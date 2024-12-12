using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminSphere.Controllers;

[Authorize(Roles = "Admin")]
public class DashboardController : AdminBaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
