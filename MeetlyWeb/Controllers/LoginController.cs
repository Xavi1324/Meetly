using Microsoft.AspNetCore.Mvc;

namespace Meetly.Controllers
{
    public class LoginController : Controller
    {
        
        public ActionResult LoginView()
        {
            return View();
        }
    }

}