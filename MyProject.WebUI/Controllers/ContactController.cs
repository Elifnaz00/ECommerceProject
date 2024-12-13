using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.ContactModel;

namespace MyProject.WebUI.Controllers
{

    public class ContactController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
       

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
           
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Index(ContactUsViewModel contactUsViewModel)
        {
            HttpClient client= _httpClientFactory.CreateClient("ApiService1");

            await client.PostAsJsonAsync(client.BaseAddress + "/Contact", contactUsViewModel);
           
            return View();
        }




        


    }
}
