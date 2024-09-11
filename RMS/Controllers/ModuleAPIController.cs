using Microsoft.AspNetCore.Mvc;

namespace RMS.Controllers
{
    [Route("api/Module")]
    [ApiController]
    public class ModuleAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
