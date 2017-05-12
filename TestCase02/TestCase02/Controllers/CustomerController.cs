using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCase02.Models;

namespace TestCase02.Controllers
{
    public class CustomerController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();

        // GET: Customer
        public ActionResult Index(string 搜尋條件 = "")
        {
            var customer = db.客戶資料.AsQueryable();                       
            var data = customer;

            if (搜尋條件 != "")
            {
                data = customer.Where(p => p.客戶名稱.Contains(搜尋條件));
            }
            return View(data.ToList());            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶資料 customer)
        {
            if (ModelState.IsValid) {
                db.客戶資料.Add(customer);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var item = db.客戶資料.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, 客戶資料 customer)
        {
            if (ModelState.IsValid)
            {
                var item = db.客戶資料.Find(id);
                item.客戶名稱 = customer.客戶名稱;
                item.統一編號 = customer.統一編號;
                item.電話 = customer.電話;
                item.傳真 = customer.傳真;
                item.地址 = customer.地址;
                item.Email = customer.Email;
                db.SaveChanges();
                
                return RedirectToAction("Index");
             }
             return View(customer);
        }

        public ActionResult Details(int id)
        {
            var item = db.客戶資料.Find(id);
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var customer = db.客戶資料.Find(id);

            db.客戶資料.Remove(customer);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}