using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Notifications;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class DeleteUserHandler : DeleteCommandHandler<User, int, DeleteUserCommand>
    {

        public DeleteUserHandler(NotificationContext notificationContext, IUserService service) 
            : base(notificationContext, service)
        {
        }
    }
}