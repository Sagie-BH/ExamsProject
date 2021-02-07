using Application.Common;
using Domain.Models;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repositories
{
    public class NotificationsRepository : Repository<UserNotification>, INotificationsRepository
    {
        public NotificationsRepository(ExamsAppDbContext context) : base(context) { }
    }
}
