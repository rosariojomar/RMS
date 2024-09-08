using Microsoft.AspNetCore.Mvc;

namespace RMS.Controllers
{
    public class RBUAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
