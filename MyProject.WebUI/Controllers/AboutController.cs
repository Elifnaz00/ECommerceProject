using Microsoft.AspNetCore.Mvc;
using MyProject.WebUI.Models.AboutModel;


namespace MyProject.WebUI.Controllers
{
    
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client= _httpClientFactory.CreateClient("ApiService1");
            var model = await client.GetFromJsonAsync<AboutListViewModel[]>(client.BaseAddress + "/About");
            return View(model);
        }
    }
}
