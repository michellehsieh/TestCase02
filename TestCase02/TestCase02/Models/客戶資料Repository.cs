using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TestCase02.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All() {
            return base.All().Where(p => p.是否已刪除 == false);
        }

        public IQueryable<客戶資料> 依客戶名稱搜尋(string 搜尋條件 = "") {
            IQueryable<客戶資料> all = this.All();

            if (搜尋條件 != "")
            {
                all = all.Where(p => p.客戶名稱.Contains(搜尋條件));
            }
            return all.OrderByDescending(p => p.Id).Take(10);
        }

        public 客戶資料 依客戶Id搜尋(int 客戶Id) {
            return this.All().FirstOrDefault(p => p.Id == 客戶Id);
        }

        public SelectList getCustomerId()
        {
            return new SelectList(this.All(), "id", "客戶名稱");
        }

        public int getCustomerByName(string custname)
        {
            return this.All()
                .Where(p => p.客戶名稱 == custname)
                .FirstOrDefault().Id;            
        }        
    }    

    public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}