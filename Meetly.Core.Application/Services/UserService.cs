using Meetly.Core.Application.Interfaces.Repositories;
using Meetly.Core.Application.Interfaces.Services;
using Meetly.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Meetly.Core.Application.Helpers;
using Meetly.Core.Application.Dtos.Email;
using Meetly.Core.Application.ViewModels.Login;
using Meetly.Core.Application.ViewModels.User;
namespace Meetly.Core.Application.Services
{
    public class UserService : GenericService<Users>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailService _mailService;

        public UserService(IUserRepository userRepository , IMailService mailService) : base(userRepository)
        {
            _userRepository = userRepository;
            _mailService = mailService;

        }
              

        public Task ActivateUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> Login(LoginViewModel loginView)
        {
            Users users = await _userRepository.LoginAsync(loginView);
            if (users == null)
            {
                throw new Exception("Usuario o contraseña incorrectos.");
            }
                

            UserViewModel userView = new();
            userView.Id = users.Id;
            userView.Name = users.Name;
            userView.LastName = users.LastName;
            userView.Email = users.Email;
            userView.PhoneNumber = users.PhoneNumber;
            userView.ProfilePicture = users.ProfilePicture;
            userView.UserName = users.UserName;
            userView.Password = users.Password;


            return userView;

        }

        public async Task<Users> RegisterAsync(Users user)
        {
            var users = await _userRepository.GetAllAsync();
            if (users.Any(u => u.UserName == user.UserName))
                throw new Exception("El nombre de usuario ya existe.");

            if(users.Any(u => u.Email == user.Email))
                throw new Exception("El correo electrónico ya está registrado.");
            await _userRepository.AddAsync(user);
            await _mailService.SendAsync(new EmailRequest
            {
                To = user.Email,
                Subject = "Bienvenido a Meetly",
                Body = $@"
        <html>
        <head>
            <style>
                body {{
                    font-family: Arial, sans-serif;
                    line-height: 1.6;
                }}
                .container {{
                    max-width: 600px;
                    margin: 0 auto;
                    padding: 20px;
                    background-color: #f4f4f4;
                    border-radius: 8px;
                }}
                .header {{
                    background-color: #007bff;
                    color: white;
                    padding: 10px;
                    text-align: center;
                    font-size: 20px;
                    font-weight: bold;
                    border-radius: 8px 8px 0 0;
                }}
                .content {{
                    padding: 20px;
                    background-color: white;
                    border-radius: 0 0 8px 8px;
                }}
                .button {{
                    display: inline-block;
                    padding: 10px 20px;
                    margin-top: 20px;
                    background-color: #007bff;
                    color: white;
                    text-decoration: none;
                    border-radius: 5px;
                    font-size: 16px;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    ¡Bienvenido a Meetly!
                </div>
                <div class='content'>
                    <p>Hola <strong>{user.Name} {user.LastName}</strong>,</p>
                    <p>Gracias por registrarte en <strong>Meetly</strong>. Estamos emocionados de tenerte con nosotros.</p>
                    <p>Para completar tu registro y activar tu cuenta, por favor haz clic en el siguiente enlace:</p>
                    <p style='text-align: center;'>
                        <a href='Lin_verified' class='button'>Verificar cuenta</a>
                    </p>
                    <p>Si no has solicitado esta cuenta, puedes ignorar este mensaje.</p>
                    <p>Saludos,<br>El equipo de Meetly</p>
                </div>
            </div>
        </body>
        </html>"
            });

            return user;
        }

        public Task ResetPasswordAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
