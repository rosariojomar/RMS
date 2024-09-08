using Microsoft.AspNetCore.Mvc;

namespace RMS.Controllers
{
    public class UserAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
