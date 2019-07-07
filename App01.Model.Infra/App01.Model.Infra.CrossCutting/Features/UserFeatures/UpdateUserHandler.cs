using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features.handlers;
using App01.Model.Infra.CrossCutting.Notifications;
using App01.Model.Service.Validators;
using AutoMapper;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class UpdateUserHandler : UpdateCommandHandler<User, int, UserValidator, UpdateUserCommand>
    {
        public UpdateUserHandler(NotificationContext notificationContext, IUserService service, IMapper mapper)
        : base(notificationContext, service, mapper)
        {
        }
    }
}