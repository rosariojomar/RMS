using Microsoft.AspNetCore.Mvc;

namespace RMS.Controllers
{
    public class UserAccountAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
