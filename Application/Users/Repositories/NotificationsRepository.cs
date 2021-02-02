using Application.Common;
using Domain.Models;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Application.Users.Repositories
{
    public class NotificationsRepository : Repository<UserNotification>, INotificationsRepository
    {
        public NotificationsRepository(ExamsAppDbContext context) : base(context) { }
    }
}
