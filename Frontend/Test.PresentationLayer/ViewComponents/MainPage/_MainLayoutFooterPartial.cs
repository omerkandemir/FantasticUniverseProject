using Microsoft.AspNetCore.Mvc;

namespace Test.PresentationLayer.ViewComponents.MainPage;

public class _MainLayoutFooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
