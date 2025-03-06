using Meetly.Core.Application.Interfaces.Repositories;
using Meetly.Core.Application.Interfaces.Services;
using Meetly.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application.Services
{
    public class UserService : GenericService<Users>, IUserService
    {
        private readonly IGenericRepository<Users> _userRepository;

        public UserService(IGenericRepository<Users> userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public Task ActivateUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Users> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<Users> RegisterAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
