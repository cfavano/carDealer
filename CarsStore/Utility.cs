using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.UI
{
    public static class Utility
    {
        public static IEnumerable<SelectListItem> CreateSelectList<T>(IList<T> entity, Func<T, object> functionToGetValue, Func<T, object> functionToGetText)
        {
            return entity
                .Select(x => new SelectListItem()
                {
                    Value = functionToGetValue(x).ToString(),
                    Text = functionToGetText(x).ToString()
                });
        }
        public static IEnumerable<SelectListItem> CreateBooleanSelectList(string trueValue, string falseValue)
        {
            var items = new List<SelectListItem>() {
                new SelectListItem() { Text = trueValue,  Value = "true"},
                new SelectListItem() { Text = falseValue, Value = "false" }
            };

            return items;

        }

        public static bool ValidatePhoneNumber(string number)
        {
            Regex pattern = new Regex(@"(?<!\d)\d{10}(?!\d)");

            if (pattern.Match(number).Success)
                return true;

            else return false;

        }

        public static bool ValidateEmail(string email)
        {
            var pattern = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
          + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
          + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");

            if (pattern.Match(email).Success)
                return true;

            else return false;

        }

        public static bool ValidateZip(string zip)
        {
            var pattern = new Regex(@"^\d{5}(-\d{4})?$");

            if (pattern.Match(zip).Success)
                return true;

            else return false;

        }
        
    }
}