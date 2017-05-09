using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCase02.Models;
using TestCase02.Models.ModelViews;

namespace TestCase02.Controllers
{
    public class BankController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();
        客戶資料MV mv = new 客戶資料MV();

        // GET: Bank
        public ActionResult Index(string 搜尋條件 = "")
        {
            var bank = db.客戶銀行資訊.AsQueryable();
            var data = bank;

            if (搜尋條件 != "") {
                data = bank.Where(p => p.銀行名稱.Contains(搜尋條件));
            }
            return View(data.ToList());             
        }

        public ActionResult Create()
        {
            ViewData["CustomerId"] = mv.getCustomerId();
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶銀行資訊 bank)
        {
            if (ModelState.IsValid) {
                db.客戶銀行資訊.Add(bank);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            ViewData["CustomerId"] = mv.getCustomerId();
            var item = db.客戶銀行資訊.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, 客戶銀行資訊 bank)
        {
            if (ModelState.IsValid)
            {
                var item = db.客戶銀行資訊.Find(id);
                item.客戶Id = bank.客戶Id;
                item.銀行名稱 = bank.銀行名稱;
                item.銀行代碼 = bank.銀行代碼;
                item.分行代碼 = bank.分行代碼;
                item.帳戶名稱 = bank.帳戶名稱;
                item.帳戶號碼 = bank.帳戶號碼;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(bank);
        }

        public ActionResult Details(int id)
        {
            ViewData["CustomerId"] = mv.getCustomerId();
            var item = db.客戶銀行資訊.Find(id);
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var bank = db.客戶銀行資訊.Find(id);

            db.客戶銀行資訊.Remove(bank);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}