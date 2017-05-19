using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCase02.Models;

namespace TestCase02.Controllers
{
    public class StatisticsController : Controller
    {
        客戶資料統計表Repository repo = new 客戶資料統計表Repository();
        
        // GET: Statistics
        public ActionResult Index() { 
            return View(repo.All());
        }
    }
}