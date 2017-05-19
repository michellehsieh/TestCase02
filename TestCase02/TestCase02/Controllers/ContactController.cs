using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCase02.Models;
using System.Data.Entity.Validation;

namespace TestCase02.Controllers
{
    public class ContactController : Controller
    {
        客戶聯絡人Repository repo = new 客戶聯絡人Repository();
        客戶資料Repository repo_customer = new 客戶資料Repository();
        
        // GET: Contact
        public ActionResult Index(string 搜尋條件 = "")
        {
            var item = repo.依姓名搜尋(搜尋條件);            
            return View(item);
        }

        public ActionResult Create()
        {
            ViewData["CustomerId"] = repo_customer.getCustomerId();
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶聯絡人 contact)
        {            
            ViewData["CustomerId"] = repo_customer.getCustomerId();
            if (ModelState.IsValid) {
                repo.Add(contact);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            ViewData["CustomerId"] = repo_customer.getCustomerId();
            var item = repo.依聯絡人Id搜尋(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {
            ViewData["CustomerId"] = repo_customer.getCustomerId();
            var contact = repo.依聯絡人Id搜尋(id);

            if (TryUpdateModel<客戶聯絡人>(contact,
                new string[] { "客戶Id", "職稱", "姓名", "Email", "手機", "電話", "是否已刪除" })) {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public ActionResult Details(int id)
        {
            var item = repo.依聯絡人Id搜尋(id);
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var contact = repo.依聯絡人Id搜尋(id);
            contact.是否已刪除 = true;
            
            try {
                repo.UnitOfWork.Commit();
            }
            catch (DbEntityValidationException ex) {
                throw ex;
            }

            return RedirectToAction("Index");
        }
    }
}