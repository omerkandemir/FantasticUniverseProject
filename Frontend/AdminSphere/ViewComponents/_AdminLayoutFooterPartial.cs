using Microsoft.AspNetCore.Mvc;

namespace AdminSphere.ViewComponents;

public class _AdminLayoutFooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
