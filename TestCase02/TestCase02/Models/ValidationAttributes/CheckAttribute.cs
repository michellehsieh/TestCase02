using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TestCase02.Models.ValidationAttributes
{
    public class CheckAttribute : DataTypeAttribute
    {
        public CheckAttribute() : base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            if (value == null) {
                return true;
            }

            if (value is String) {
                return Regex.IsMatch(value.ToString(), "[0-9]{4}-[0-9]{6}");
            } else {
                return true;
            }                 
        }

    }
}