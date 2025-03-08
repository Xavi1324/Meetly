using Meetly.Core.Application.Helpers;
using Meetly.Core.Application.Interfaces.Repositories;
using Meetly.Core.Application.ViewModels.Login;
using Meetly.Core.Domain.Entities;
using Meetly.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Infrastructure.Persistence.Repositories.User
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        private readonly MeetlyContext _context;

        public UserRepository(MeetlyContext context) : base(context)
        {
            _context = context;
        }

        public override async Task AddAsync(Users entity)
        {
            entity.Password = PasswordEncrytion.ComputeSha265Hash(entity.Password);
            await base.AddAsync(entity);

        }
        public async Task<Users> LoginAsync(LoginViewModel loginVm)
        {
            string PasswordEncrypted = PasswordEncrytion.ComputeSha265Hash(loginVm.Password);
            Users user =  await _context.Set<Users>().FirstOrDefaultAsync(u => u.Email == loginVm.Email && u.Password == PasswordEncrypted);
            return user;


        }

    }
}
