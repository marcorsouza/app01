using System;
using System.Threading;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Notifications;
using App01.Model.Service.Validators;
using MediatR;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IUserService _userService;

        public CreateUserHandler(NotificationContext notificationContext, IUserService userService)
        {
            _notificationContext = notificationContext;
            _userService = userService;
        }

        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.Name,
                Email = request.Email,
                Active = true,
                Cpf = request.Cpf,
                BirthDate = request.BirthDate
            };

            user.Authentication.Username = request.AuthenticationUserName;
            user.Authentication.Password = request.AuthenticationPassword;

            _userService.Post<UserValidator>(user);

            if (user.Invalid)
            {
                _notificationContext.AddNotifications(user.ValidationResult);
                return null;
            }

            return user;
        }
    }
}