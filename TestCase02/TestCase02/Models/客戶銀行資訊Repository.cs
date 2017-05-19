using System;
using System.Linq;
using System.Collections.Generic;
	
namespace TestCase02.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All() {
            return base.All().Where(p => p.是否已刪除 == false);
        }

        public IQueryable<客戶銀行資訊> 依銀行名稱搜尋(string 搜尋條件 = "") {
            IQueryable<客戶銀行資訊> all = this.All();

            if (搜尋條件 != "")
            {
                all = all.Where(p => p.銀行名稱.Contains(搜尋條件));
            }
            return all.OrderByDescending(p => p.Id).Take(10);
        }

        public 客戶銀行資訊 依銀行Id搜尋(int 銀行Id)
        {
            return this.All().FirstOrDefault(p => p.Id == 銀行Id);
        }
    }

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}