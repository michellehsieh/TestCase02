using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCase02.Models;
using TestCase02.Models.ModelViews;

namespace TestCase02.Controllers
{
    public class ContactController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();
        客戶資料MV mv = new 客戶資料MV();

        // GET: Contact
        public ActionResult Index(string 搜尋條件 = "")
        {
            var contact = db.客戶聯絡人.AsQueryable();                             
            var data = contact;

            if (搜尋條件 != "")
            {
                data = contact.Where(p => p.姓名.Contains(搜尋條件));
            }
            return View(data.ToList());           
        }

        public ActionResult Create()
        {            
            ViewData["CustomerId"] = mv.getCustomerId();
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶聯絡人 contact)
        {
            if (ModelState.IsValid) {
                db.客戶聯絡人.Add(contact);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            ViewData["CustomerId"] = mv.getCustomerId();
            var item = db.客戶聯絡人.Find(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, 客戶聯絡人 contact)
        {
            if (ModelState.IsValid)
            {
                var item = db.客戶聯絡人.Find(id);
                item.客戶Id = contact.客戶Id;
                item.職稱 = contact.職稱;
                item.姓名 = contact.姓名;
                item.Email = contact.Email;
                item.手機 = contact.手機;
                item.電話 = contact.電話;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public ActionResult Details(int id)
        {
            var item = db.客戶聯絡人.Find(id);
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var contact = db.客戶聯絡人.Find(id);

            db.客戶聯絡人.Remove(contact);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}