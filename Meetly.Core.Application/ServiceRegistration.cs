using Meetly.Core.Application.Interfaces.Services;
using Meetly.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetly.Core.Application
{
    public  static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
           
            services.AddTransient<IUserService, UserService>();
        }
    }
}
