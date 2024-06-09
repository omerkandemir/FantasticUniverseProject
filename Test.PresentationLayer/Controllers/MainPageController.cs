using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Test.PresentationLayer.Controllers;

[Authorize]
public class MainPageController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
