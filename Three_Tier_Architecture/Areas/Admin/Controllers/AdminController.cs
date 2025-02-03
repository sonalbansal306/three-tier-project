using Microsoft.AspNetCore.Mvc;

namespace Three_Tier_Architecture.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Areas/Admin/Views/Admin/Index.cshtml");
        }
    }
}
