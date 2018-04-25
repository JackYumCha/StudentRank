using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//可以直接copy,默认访问静态网页
namespace RankAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Spa()
        {
            return File("~/index.html", "text/html");
        }
    }

}
