namespace TestCase02.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using ValidationAttributes;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        客戶聯絡人Repository repo = new 客戶聯絡人Repository();
        客戶資料Repository repo1 = new 客戶資料Repository();
        
        public string 客戶名稱
        {
            get {                
                return repo1.依客戶Id搜尋(客戶Id).客戶名稱;
            }
        }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            var customerId = repo1.getCustomerByName(this.客戶名稱);
            var item = repo.判斷email(this.Id, customerId, this.Email);           
            
            if (item.ToList().Count > 1) {
                yield return new ValidationResult("該客戶已存在同一Email，請重新確認！", new string[] { "Email" });
            } 
             yield break;             
         }

}
    
    public partial class 客戶聯絡人MetaData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "請選擇客戶！")]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "請輸入職稱！")]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "請輸入姓名！")]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required(ErrorMessage = "請輸入Email！")]
        [EmailAddress]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "請輸入手機！")]
        [CheckAttribute(ErrorMessage ="手機格式不符！")]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required(ErrorMessage = "請輸入電話！")]
        public string 電話 { get; set; }

        public bool 是否已刪除 { get; set; }

        public virtual 客戶資料 客戶資料 { get; set; }  
    }

    
}
