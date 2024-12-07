using Microsoft.AspNetCore.Mvc;

namespace MyProject.WebUI.Controllers
{
    
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
