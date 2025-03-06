using Meetly.Core.Application.Interfaces.Repositories;
using Meetly.Infrastructure.Persistence.Contexts;
using Meetly.Infrastructure.Persistence.Repositories;
using Meetly.Infrastructure.Persistence.Repositories.Comment;
using Meetly.Infrastructure.Persistence.Repositories.Friend;
using Meetly.Infrastructure.Persistence.Repositories.Post;
using Meetly.Infrastructure.Persistence.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetly.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersitence(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database Configuration
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<MeetlyContext>(options => options.UseInMemoryDatabase("MeetlyDbMemory"));
            }
            else
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<MeetlyContext>(options => 
                options.UseSqlServer(connectionString, m => m.MigrationsAssembly(typeof(MeetlyContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories Dependency Injection
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository , UserRepository>();
            services.AddTransient<ICommentsRepository, CommentRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IFriendshipRepository, FriendshipRepository>();
            #endregion

        }
    }
}
