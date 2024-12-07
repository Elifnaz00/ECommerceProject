using Microsoft.AspNetCore.Mvc;

namespace MyProject.WebUI.Controllers
{
    
    public class AboutController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
