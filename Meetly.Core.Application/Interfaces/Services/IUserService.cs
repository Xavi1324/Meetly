using Meetly.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<Users>
    {        
        Task<Users> RegisterAsync(Users user);
        Task<Users> LoginAsync(string username, string password);
        Task ActivateUserAsync(int userId);
        Task ResetPasswordAsync(string username);
    }
}
