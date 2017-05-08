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
            return new SelectList(db.客戶資料, "id", "客戶名稱");   
        }        
    }
}