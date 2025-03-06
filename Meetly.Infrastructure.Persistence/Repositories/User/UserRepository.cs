using Meetly.Core.Application.Helpers;
using Meetly.Core.Application.Interfaces.Repositories;
using Meetly.Core.Domain.Entities;
using Meetly.Infrastructure.Persistence.Contexts;
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
            entity.Password = PasswordEncrytion.Encrypt(entity.Password);
            await base.AddAsync(entity);
        }


    }
}
