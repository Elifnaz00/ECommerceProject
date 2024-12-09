using Azure;
using Microsoft.AspNetCore.Mvc;
using MyProject.DataAccess.Context;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;

using MyProject.WebUI.Models.ProductModel;
using PagedList;
using System.Collections.Generic;
using System.Net.Http;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace MyProject.WebUI.Controllers
{
    
    public class ShopController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ShopController> _logger;

        public ShopController(IHttpClientFactory httpClientFactory, ILogger<ShopController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> ShopProductList()
        {
            var client = _httpClientFactory.CreateClient("ApiService1");
            
            // Tüm ürünleri al
            HttpResponseMessage httpResponseMessage = await client.GetAsync(client.BaseAddress + "/Product/GetProduct");
            httpResponseMessage.EnsureSuccessStatusCode();

            var allProducts = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<ProductListVewModel>>()
                              ?? new List<ProductListVewModel>();
            return View(allProducts);

        }





        [HttpGet("GetProductByCategory/{categoryId}")]
        public async Task<IActionResult> GetProductByCategory(Guid? categoryId) {

            var client = _httpClientFactory.CreateClient("ApiService1");
            
            // Kategoriye göre filtrele
            HttpResponseMessage httpResponseMessage = await client.GetAsync(client.BaseAddress + $"/Product/Productbycategory/{categoryId}");
            httpResponseMessage.EnsureSuccessStatusCode();

            var products = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<ProductListVewModel>>()
                           ?? new List<ProductListVewModel>();
            return View("ShopProductList", products);

        }


        [HttpGet("ProductDetails/{id}")]
        public async Task<IActionResult> ProductDetails(Guid? id) 
        {
            if (!id.HasValue)
            {
                _logger.LogWarning("Ürün detayları için geçersiz bir ID sağlandı.");
                return BadRequest("Geçersiz ID.");
            }

            var client = _httpClientFactory.CreateClient("ApiService1");

            try
            {
                // API'ye GET isteği gönder
                var httpResponseMessage = await client.GetAsync($"{client.BaseAddress}/Product/Productdetail/{id}");

                // HTTP yanıt durumunu kontrol et
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    var errorResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    _logger.LogError($"API Hatası: {httpResponseMessage.StatusCode}, Yanıt: {errorResponse}");
                    return StatusCode((int)httpResponseMessage.StatusCode, "Ürün detayları alınamadı.");
                }

                // JSON'u deserialization yap
                var product = await httpResponseMessage.Content.ReadFromJsonAsync<ProductDetailViewModel>();

                if (product == null)
                {
                    _logger.LogError("Deserialization işlemi sırasında ürün bilgisi alınamadı.");
                    return StatusCode(500, "Ürün detayları alınamadı.");
                }

                // Tekil nesneyi liste haline getir
                //var products = new List<ProductDetailViewModel> { product };
                
                // View'a gönder
                return View(product);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "API çağrısı sırasında bir hata oluştu.");
                return StatusCode(500, "API çağrısı sırasında bir hata oluştu.");
            }

        }

        
        [HttpGet("GetFilteredProducts")]
        public async Task<IActionResult> GetFilteredProducts(string? category, string? size, string? color, long? price)
        {

            var client = _httpClientFactory.CreateClient("ApiService1");
           
            var response = await client.GetAsync(client.BaseAddress + "/Product/GetFiltered?" +
            $"category={category}&size={size}&color={color}&price={price}");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Ürünler alınırken bir hata oluştu.");
            }

            var data = await response.Content.ReadFromJsonAsync<dynamic>();
            return Json(data);
        }
        











    }
}
