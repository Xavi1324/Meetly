using Meetly.Core.Application.ViewModels.Login;
using Meetly.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<Users> 
    {
        Task<Users> LoginAsync(LoginViewModel loginVm);
    }
}
