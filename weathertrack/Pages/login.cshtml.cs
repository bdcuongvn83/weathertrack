using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;

namespace weathertrack.Pages
{
    
    public class LoginModel : PageModel
    {
        public string name;
        public int age;
        public void OnGet()
        {
            
        }
        public void OnPost()
        {
            name = toEmpty(Request.Form["Name"]);
            HttpContext.Session.SetString("Name", name);
            age = Convert.ToInt32(Request.Form["Age"]);
            HttpContext.Session.SetInt32("Age", age);
            Response.Redirect("./welcome");
        }

        private string toEmpty(StringValues value)
        {
            return StringValues.IsNullOrEmpty(value) ? "" : value.ToString();
        }
    }
}
