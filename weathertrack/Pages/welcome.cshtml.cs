using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace weathertrack.Pages
{
    public class WelcomeModel : PageModel
    {
        public string name = "";
        public int age= 0;
        public string SessionId { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("Name") != null)
                name = HttpContext.Session.GetString("Name");
            if (HttpContext.Session.GetInt32("Age") != null)
                age = (Int32)HttpContext.Session.GetInt32("Age");

            SessionId = HttpContext.Features.Get<ISessionFeature>().Session.Id;
        }
    }
}
