using Microsoft.AspNetCore.Mvc;

namespace Three_Tier_Architecture.Areas.User.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
