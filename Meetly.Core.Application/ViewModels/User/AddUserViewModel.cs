using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.ViewModels.User
{
    public class AddUserViewModel
    {

        [Required(ErrorMessage= "You must put your name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must put your lastname")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "You must put your phone number")]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "You must put your Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must upload a profile photo")]
        [DataType(DataType.Text)]
        public IFormFile ProfilePicture { get; set; }
        [Required(ErrorMessage = "You must put your username")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "You must put a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        [Required(ErrorMessage = "You must confirm the password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
