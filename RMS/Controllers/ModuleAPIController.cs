using Microsoft.AspNetCore.Mvc;

namespace RMS.Controllers
{
    public class ModuleAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
