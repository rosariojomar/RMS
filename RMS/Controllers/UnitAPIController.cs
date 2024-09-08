using Microsoft.AspNetCore.Mvc;

namespace RMS.Controllers
{
    public class UnitAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
