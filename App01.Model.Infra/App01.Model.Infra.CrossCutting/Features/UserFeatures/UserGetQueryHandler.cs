using App01.Model.Domain.Entities;
using App01.Model.Domain.Services;
using App01.Model.Infra.CrossCutting.Features.handlers;
using App01.Model.Infra.CrossCutting.Notifications;

namespace App01.Model.Infra.CrossCutting.Features.UserFeatures
{
    public class UserGetQueryHandler : GetQueryHandler<User, int, UserGetQuery>
    {

        public UserGetQueryHandler(NotificationContext notificationContext, IUserService service) : base(notificationContext, service)
        {
        }
    }
}