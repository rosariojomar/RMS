using Microsoft.AspNetCore.Mvc;

namespace RMS.Controllers
{
    public class DepartmentAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
