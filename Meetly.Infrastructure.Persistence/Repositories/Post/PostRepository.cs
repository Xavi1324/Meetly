using Meetly.Core.Application.Interfaces.Repositories;
using Meetly.Core.Domain.Entities;
using Meetly.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Infrastructure.Persistence.Repositories.Post
{
    public class PostRepository: GenericRepository<Posts>, IPostRepository
    {
        private readonly MeetlyContext _context;
        public PostRepository(MeetlyContext context) : base(context)
        {
            _context = context;
        }
    }
}
