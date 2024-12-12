using Microsoft.AspNetCore.Mvc;

namespace AdminSphere.ViewComponents;

public class _AdminLayoutSidebarPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
