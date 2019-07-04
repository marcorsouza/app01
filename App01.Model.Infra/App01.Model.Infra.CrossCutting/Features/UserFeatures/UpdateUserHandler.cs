using System.Threading;
using System.Threading.Tasks;
using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Notifications;
using App01.Model.Service.Validators;
using MediatR;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser, User>
    {
        private readonly NotificationContext _notificationContext;
        private readonly IUserService _userService;

        public UpdateUserHandler(NotificationContext notificationContext, IUserService userService)
        {
            _notificationContext = notificationContext;
            _userService = userService;
        }

        public async Task<User> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var user = _userService.Get(request.Id).Result;
            user.Name = request.Name;
            user.Email = request.Email;
            user.Cpf = request.Cpf;
            user.BirthDate = request.BirthDate;
            
            _userService.Put<UserValidator>(user);

            if (user.Invalid)
            {
                _notificationContext.AddNotifications(user.ValidationResult);
                return null;
            }

            return user;
        }
    }
}