using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.UserModel;
using System.ClientModel;
using System.Reflection.Metadata.Ecma335;

namespace MyProject.WebUI.Controllers
{
    public class LoginController : Controller
    {

        private readonly SignInManager<AppUser> _signInManager; 
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserLoginViewModel userLoginViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userLoginViewModel);

            }
            
                
                HttpClient client = _httpClientFactory.CreateClient("ApiService1");

                var response = await client.PostAsJsonAsync(client.BaseAddress + "/User/Login", userLoginViewModel);

            
           

            if (response.IsSuccessStatusCode)
            {
                var user = new AppUser
                {
                    UserName = userLoginViewModel.UserName
                };

                //kullanıcıyı oturum açmış olarak işaretleme
                await _signInManager.SignInAsync(user, false);
               

                return RedirectToAction("Index", "Home");
            }

            else
                {
                    ModelState.AddModelError(string.Empty, "Geçersiz Giriş Denemesi.");
                    return View(userLoginViewModel);
                }

     
        }



        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }






        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModeL userRegisterViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterViewModel);
               

            }

            
                HttpClient client = _httpClientFactory.CreateClient("ApiService1");

                var response = await client.PostAsJsonAsync(client.BaseAddress + "/User/Register", userRegisterViewModel);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Success = "Kayıt işlemi başarılı. Giriş yapabilirsiniz.";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    string errorMessage= await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, $"Kayıt işlemi başarısız: {errorMessage}");
            }
            
         
           

            
            return View(userRegisterViewModel);





        } 
    }
}
