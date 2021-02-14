﻿using Application.Common;
using Domain.Entities.UserEntities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Application.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ExamsAppDbContext context) : base(context) { }
    }
}