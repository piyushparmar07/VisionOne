using Microsoft.AspNetCore.Mvc;

namespace VisionOne.UI.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
