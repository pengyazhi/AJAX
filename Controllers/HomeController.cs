using AJAX.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AJAX.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult First()
        {
            return View();
        }
        
        public IActionResult GetDemo()
        {
            return View();

        }
        public IActionResult register()
        {
            return View();
            //<form action="~/api/getdemo" method="post">
            //畫面上的form如果沒有指定action >> 預設為將資料回傳給自己  (HomeController>>register)
            //畫面上的form如果沒有指定method >> 預設為get (輸入框的key(name屬性)會將其value顯示在url上) 使用post會封包在url裡
        }
    }
}