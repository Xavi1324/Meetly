using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.Dtos.Account
{
    public class UpdateUserProfileRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IFormFile? FotoPerfil { get; set; } 
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
