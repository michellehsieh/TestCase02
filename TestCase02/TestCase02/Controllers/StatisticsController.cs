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
        // GET: Statistics
        public ActionResult Index()
        {
            客戶資料Entities db = new 客戶資料Entities();

            var data = db.客戶資料統計表.AsQueryable();

            return View(data.ToList());
        }
    }
}