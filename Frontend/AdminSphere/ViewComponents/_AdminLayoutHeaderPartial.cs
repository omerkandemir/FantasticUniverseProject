using Microsoft.AspNetCore.Mvc;

namespace AdminSphere.ViewComponents;

public class _AdminLayoutHeaderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
