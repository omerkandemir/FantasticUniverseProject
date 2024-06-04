using Microsoft.AspNetCore.Mvc;
using Test.PresentationLayer.Models;

namespace Test.PresentationLayer.Controllers;

public class ConfirmMailController : Controller
{
    [HttpGet]
    public IActionResult Index(int Id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(ConfirmMailViewModel confirmMailViewModel)
    {

        return View();
    }
}
