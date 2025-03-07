using Meetly.Core.Application.Dtos.Email;

namespace Meetly.Core.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(EmailRequest request);
    }
}
