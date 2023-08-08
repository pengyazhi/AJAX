using AJAX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAX.Controllers
{
    public class ApiForHomeworkController : Controller
    {
        private DemoContext _db;
        public ApiForHomeworkController(DemoContext db)
        {
            _db= db;
        }
        public IActionResult CheckValue(Members member)
        {
            bool isMemberExist = _db.Members.Select(n=>n.Name.ToUpper()).Any(n=>n == member.Name.ToUpper());
            if (isMemberExist)
            {
                return Content("true");
                //return Content($"{member.Name} 會員已經存在!");
            }
            return Content("false");   
            //return Content("新增會員成功");
        }
    }
}
