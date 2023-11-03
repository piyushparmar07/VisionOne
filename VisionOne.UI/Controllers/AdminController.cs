using Microsoft.AspNetCore.Mvc;

namespace VisionOne.UI.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
