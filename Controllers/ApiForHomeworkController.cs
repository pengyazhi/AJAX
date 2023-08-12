using AJAX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AJAX.Controllers
{
    public class ApiForHomeworkController : Controller
    {
        private DemoContext _db;
        private readonly IWebHostEnvironment _host;
        public ApiForHomeworkController(DemoContext db , IWebHostEnvironment host)
        {
            _db= db;
            _host= host;
        }
        public IActionResult CheckValue(Members member)
        {
            bool isMemberExist = _db.Members.Select(n=>n.Name.ToUpper()).Any(n=>n == member.Name.ToUpper());
           
            if (isMemberExist)
            {
                return Content("0");
                //return Content($"{member.Name} 會員已經存在!");
            }
            return Content("1");   
            //return Content("新增會員成功");
        }
        public IActionResult getImgStream(IFormFile file) 
        {
            byte[]? imgBytes = null;
            using (var memoryStream =new MemoryStream())
            {
                file.CopyTo(memoryStream);
                imgBytes = memoryStream.ToArray();
            }
            return File(imgBytes,"image/jpg");
        }
        //public IActionResult getImgById(int id = 1)
        //{
        //    //先用id找到member的id
        //    Members? member = _db.Members.Find(id);
        //    byte[]? img = member.FileData;
        //    return File(img, "image/jpg");
        //}
    }
}
