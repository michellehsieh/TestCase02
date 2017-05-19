using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCase02.Models;

namespace TestCase02.Controllers
{
    public class CustomerController : Controller
    {
        客戶資料Repository repo = RepositoryHelper.Get客戶資料Repository();

        // GET: Customer
        public ActionResult Index(string 搜尋條件 = "")
        {
            var customer = repo.依客戶名稱搜尋(搜尋條件);
            return View(customer);            
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶資料 customer)
        {
            if (ModelState.IsValid) {
                repo.Add(customer);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var item = repo.依客戶Id搜尋(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form)
        {            
            var item = repo.依客戶Id搜尋(id);

            if (TryUpdateModel<客戶資料>(item,
                new string[] { "客戶名稱", "統一編號", "電話", "傳真", "地址", "Email", "是否已刪除" })) {
                    
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public ActionResult Details(int id)
        {
            var item = repo.依客戶Id搜尋(id);
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var customer = repo.依客戶Id搜尋(id);
                        
            customer.是否已刪除 = true;

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