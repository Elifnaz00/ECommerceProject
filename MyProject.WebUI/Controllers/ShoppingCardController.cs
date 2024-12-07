using Microsoft.AspNetCore.Mvc;


namespace MyProject.WebUI.Controllers
{
    public class ShoppingCardController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ShoppingCardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /*

        [HttpPost]  
        public IActionResult AddToShoppingCard(AddToShoppingCardViewModel addToShoppingCardViewModel)
        {
            HttpClient client= _httpClientFactory.CreateClient("ApiService1");
            client.GetAsync(client.BaseAddress).Wait();
            return View();
        }

        */



    }
}
