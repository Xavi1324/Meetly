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
            
            return View( new AddUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                string profilePicturePath = null;
                if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                    Directory.CreateDirectory(uploadsFolder); // Asegurar que el directorio existe

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ProfilePicture.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProfilePicture.CopyToAsync(stream);
                    }

                    profilePicturePath = "/uploads/" + fileName;
                }

                var newUser = new Users
                {
                    Name = model.Name,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber,
                    ProfilePicture = profilePicturePath,
                    Password = model.Password
                };

                await _userService.RegisterAsync(newUser);

                return RedirectToAction("LoginView", "Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

    }
}
