using Microsoft.AspNetCore.Mvc;

namespace RMS.Controllers
{
    public class UserPolicyAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
