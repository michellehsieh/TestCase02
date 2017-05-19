using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCase02.Models;

namespace TestCase02.Controllers
{
    public class BankController : Controller
    {
        客戶銀行資訊Repository repo = new 客戶銀行資訊Repository();
        客戶資料Repository repo_customer = new 客戶資料Repository();

        // GET: Bank
        public ActionResult Index(string 搜尋條件 = "")
        {
            var bank = repo.依銀行名稱搜尋(搜尋條件);            
            return View(bank);             
        }

        public ActionResult Create()
        {
            ViewData["CustomerId"] = repo_customer.getCustomerId();
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶銀行資訊 bank)
        {
            if (ModelState.IsValid) {
                repo.Add(bank);
                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            ViewData["CustomerId"] = repo_customer.getCustomerId();
            var item = repo.依銀行Id搜尋(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form) {           
            var item = repo.依銀行Id搜尋(id);
            if (TryUpdateModel<客戶銀行資訊>(item,
                new string[] { "客戶Id", "銀行名稱", "銀行代碼", "分行代碼", "帳戶名稱", "帳戶號碼", "是否已刪除" })) {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }               
            return View(item);
        }

        public ActionResult Details(int id)
        {
            ViewData["CustomerId"] = repo_customer.getCustomerId();
            var item = repo.依銀行Id搜尋(id);
            return View(item);
        }

        public ActionResult Delete(int id)
        {
            var bank = repo.依銀行Id搜尋(id);
            bank.是否已刪除 = true;
            
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