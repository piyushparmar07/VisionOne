using Microsoft.AspNetCore.Mvc;

namespace VisionOne.UI.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
