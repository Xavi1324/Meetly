using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.Dtos.Account
{
    public class AuthenticationResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FotoPerfilUrl { get; set; }
        public bool IsVerified { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
