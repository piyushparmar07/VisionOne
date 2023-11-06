using Microsoft.AspNetCore.Mvc;
using VisionOne.BAL.Service;
using VisionOne.BAL.Service.Interface;

namespace VisionOne.UI.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        public LoginController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.SetString("Name", string.Empty);
            HttpContext.Session.SetString("Role", string.Empty);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string Email, string password)
        {
            string strEmail = Email;
            var issuccess = _userService.AuthenticateUser(Email, password);

            if (issuccess != null)
            {
                string Name = issuccess.FirstName+" "+issuccess.LastName;
                
                HttpContext.Session.SetString("Name", Name);
                HttpContext.Session.SetString("Role", issuccess.Role.Name);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.message = string.Format("Please enter valid credentials");
                return View();
            }
        }
    }
}
