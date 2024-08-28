using Microsoft.AspNetCore.Mvc;

namespace Test.PresentationLayer.ViewComponents.MainPage;

public class _MainLayoutHeaderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
