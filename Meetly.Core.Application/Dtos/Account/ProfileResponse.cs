using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.Dtos.Account
{
    public class ProfileResponse
    {
        public bool HasError { get; set; }
        public string Error { get; set; }
        public string UserId { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FotoPerfilUrl { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
