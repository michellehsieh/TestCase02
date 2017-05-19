using System;
using System.Linq;
using System.Collections.Generic;
	
namespace TestCase02.Models
{   
	public  class 客戶資料統計表Repository : EFRepository<客戶資料統計表>, I客戶資料統計表Repository
	{
        public override IQueryable<客戶資料統計表> All() {
            return base.All();
        }
	}

	public  interface I客戶資料統計表Repository : IRepository<客戶資料統計表>
	{

	}
}