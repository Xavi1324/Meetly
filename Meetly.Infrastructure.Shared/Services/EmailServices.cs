using MailKit.Net.Smtp;
using MailKit.Security;
using Meetly.Core.Application.Interfaces.Services;
using Meetly.Core.Domain.Setting;
using Microsoft.Extensions.Options;
using MimeKit;
using Meetly.Core.Application.Dtos.Email;

namespace Meetly.Infrastructure.Shared.Services
{
    public class EmailServices : IMailService
    {
		private MailSettings _mailSettings { get; }
        public EmailServices(IOptions<MailSettings> mailsetting)
		{
            _mailSettings = mailsetting.Value;
        }
        public async Task SendAsync(EmailRequest request)
        {
			try
			{
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(request.From ?? _mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
			catch (Exception ex)
			{

				throw;  
			}
        }
    }
}
