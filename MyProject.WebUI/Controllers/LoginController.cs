using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.Entity.Entities;
using MyProject.WebUI.Models.UserModel;

namespace MyProject.WebUI.Controllers
{
    public class LoginController : Controller
    {


        private readonly UserManager<AppUser> _userManager;
        

        public LoginController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        
        public IActionResult Index()
        {

            return Ok();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModeL userRegisterViewModel)
        {

            AppUser user = new AppUser()
            {
                Email = userRegisterViewModel.Email,
                NameSurname = userRegisterViewModel.NameSurname,
                UserName = userRegisterViewModel.UserName,
            };
            var result = await _userManager.CreateAsync(user, userRegisterViewModel.Password);
            if (result.Succeeded)
            {
                return Ok("User registered successfully!");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
