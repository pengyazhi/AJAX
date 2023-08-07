using Microsoft.AspNetCore.Mvc;

namespace AJAX.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello Ajax!!");
        }
    }
}
