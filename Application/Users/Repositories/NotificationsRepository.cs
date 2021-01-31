using Application.Common;
using Domain.Models;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Application.Users.Repositories
{
    public class NotificationsRepository : EfRepository<UserNotification>, INotificationsRepository
    {
        public NotificationsRepository(ExamPrjDbContext context) : base(context) { }
    }
}
