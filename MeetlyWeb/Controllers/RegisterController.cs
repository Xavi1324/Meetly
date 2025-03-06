using Meetly.Core.Application.Interfaces.Services;
using Meetly.Core.Application.ViewModels.User;
using Meetly.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SaludPro.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Register(AddUserViewModel model, IFormFile ProfilePicture)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string profilePicturePath = null;
            if (ProfilePicture != null && ProfilePicture.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                Directory.CreateDirectory(uploadsFolder);
                profilePicturePath = Path.Combine(uploadsFolder, ProfilePicture.FileName);

                using (var stream = new FileStream(profilePicturePath, FileMode.Create))
                {
                    await ProfilePicture.CopyToAsync(stream);
                }

                // Guardamos la ruta de la imagen en el modelo
                model.ProfilePicture = "/uploads/" + ProfilePicture.FileName;
            }

            var newUser = new Users
            {
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName,
                PhoneNumber = model.PhoneNumber,
                ProfilePicture = model.ProfilePicture,
                Password = model.Password
            };

            await _userService.Add(newUser);

            return RedirectToAction("LoginView", "Login");
        }


    }
}
