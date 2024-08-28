using Microsoft.AspNetCore.Mvc;

namespace Test.PresentationLayer.ViewComponents.MainPage;

public class _MainLayoutHeadPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
