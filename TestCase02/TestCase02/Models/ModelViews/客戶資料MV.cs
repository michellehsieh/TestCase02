using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCase02.Models.ModelViews
{
    public class 客戶資料MV
    {
        客戶資料Entities db = new 客戶資料Entities();

        public SelectList getCustomerId() {
            return new SelectList(db.客戶資料.Where(p => p.是否已刪除 == false), "id", "客戶名稱");   
        }

        public int getCustomerByName(string custname) {

            var customer = db.客戶資料.AsQueryable();
            var data = customer.Where(p => p.客戶名稱 == custname);
            return data.FirstOrDefault().Id;
        }      
    }
}