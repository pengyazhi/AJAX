using AJAX.Models;
using AJAX.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace AJAX.Controllers
{
    public class ApiController : Controller
    {

        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;
        //要先在「Program」DI 「DemoContext」 才能順利從資料庫抓到資料並執行
        public ApiController(DemoContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        public IActionResult Index()
        {
            //Thread.Sleep(5000);
            return Content("Hello Fetch!!");
        }
        public IActionResult getdemo(CUserInfoViewModel user) //public IActionResult getdemo(string name,int age=30)
        {
            //使用預設值的方法有兩種,1:寫在參數 2.判斷為空值再給他預設值
            //使用類別當參數要類別裡的屬性跟畫面上的name名稱一致
            if (string.IsNullOrEmpty(user.name))
            {
                user.name = "guest";
            }

            return Content($"Hello {user.name}! You are {user.age} years old.");
        }
        public IActionResult register(Members member, IFormFile file)
        {
            if (file != null)
            {
                string filePath = Path.Combine(_host.WebRootPath, "uploads", file.FileName);
                using (var filestrem = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(filestrem);
                }
                byte[]? imgBytes = null;
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    imgBytes = memoryStream.ToArray();
                }
                //用這個方式可能會覆蓋相同檔名的圖片
                //TODO 使用GUID
                member.FileName = file.FileName;
                member.FileData = imgBytes;
            }
            _context.Members.Add(member);
            _context.SaveChanges();
            return Content("註冊成功!");
            //return Content($"檔案{file.FileName}成功存入{filePath}中");
        }
        public IActionResult getImgById(int id = 1) 
        {
            //先用id找到member的id
            Members? member = _context.Members.Find(id);
            byte[]? img = member.FileData;
            return File(img, "image/jpg");
        }
        public IActionResult City()
        {
            var cities = _context.Address.Select(c => c.City).Distinct();
            return Json(cities);
        }
        public IActionResult District(string city)
        {
            var districts = _context.Address.Where(c => c.City == city).Select(c => c.SiteId).Distinct();
            return Json(districts);
        }
        public IActionResult Road(string siteId)
        {
            var roads = _context.Address.Where(c => c.SiteId == siteId).Select(c => c.Road).Distinct();
            return Json(roads);
        }
    }
}
