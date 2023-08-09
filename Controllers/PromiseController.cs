using Microsoft.AspNetCore.Mvc;

namespace AJAX.Controllers
{
    public class PromiseController : Controller
    {
        public IActionResult Promise()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }
    }
}
