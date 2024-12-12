using Microsoft.AspNetCore.Mvc;

namespace AdminSphere.ViewComponents;

public class _AdminLayoutHeadPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
