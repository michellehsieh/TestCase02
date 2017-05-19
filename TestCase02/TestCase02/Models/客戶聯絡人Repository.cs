using System;
using System.Linq;
using System.Collections.Generic;
	
namespace TestCase02.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.是否已刪除 == false);
        }

        public IQueryable<客戶聯絡人> 依姓名搜尋(string 搜尋條件 = "")
        {
            IQueryable<客戶聯絡人> all = this.All();

            if (搜尋條件 != "")
            {
                all = all.Where(p => p.姓名.Contains(搜尋條件));
            }
            return all.OrderByDescending(p => p.Id).Take(10);
        }

        public 客戶聯絡人 依聯絡人Id搜尋(int 聯絡人Id)
        {
            return this.All().FirstOrDefault(p => p.Id == 聯絡人Id);
        }

        public IQueryable<客戶聯絡人> 判斷email(int Id, int custId, string Email)
        {
            return this.All()
                .Where(p => p.Id != Id && p.客戶Id == custId && p.是否已刪除 == false && p.Email == Email);
        }
    }

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}