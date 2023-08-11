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
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult History()
        {
            return View();
        }
        public IActionResult jQuery()
        {
            return View();
        }
        public IActionResult ShipperCors()
        {
            return View();
        }
        public IActionResult ShipperCorsEmpty()
        {
            return View();
        }
        public IActionResult partialTest()
        {
            //建立view時要選擇"建立成局部檢視" 並 return PartialView();
            return PartialView();
            //長在畫面上的兩種方法
            //1.HtmlHelper : 使用@Html.Partial("partialTest")
            //2.jQuery : $('#buttonLoad').click(function () { $('#divAlert').load('@Url.Content("~/Home/partialTest")')

        }
        public IActionResult partialTest2()
        {
            ViewBag.message = "我有經過action";
            return PartialView();
        }
    }
}