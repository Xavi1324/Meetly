using Meetly.Core.Application.Interfaces.Services;
using Meetly.Core.Domain.Setting;
using Meetly.Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meetly.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, EmailServices>();
        }



    }
}
