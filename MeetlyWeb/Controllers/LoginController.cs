using Meetly.Core.Application.Interfaces.Services;
using Meetly.Core.Application.ViewModels.Login;
using Meetly.Core.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Meetly.Core.Application.Helpers;
using System;

namespace Meetly.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult LoginView()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UserViewModel userVm = await _userService.Login(model);
            if (userVm != null) 
            {
                HttpContext.Session.Set<UserViewModel>("user", userVm);
                return RedirectToRoute(new { controller = "Home", action = "Home" });
                    
            }
            else
            {
                ModelState.AddModelError("userValidation", "Email o contraseña incorrectos.");
            }
            return View(model);
        }
    }

}