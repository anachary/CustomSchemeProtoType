
using Microsoft.AspNetCore.Mvc;

namespace PoliciesAuthApp1.Controllers
{
    public class DefaultController : Controller
    {  
        public DefaultController()
        {
        }
        public IActionResult Test()
        {
            return Json("default");
        }
    }
}
