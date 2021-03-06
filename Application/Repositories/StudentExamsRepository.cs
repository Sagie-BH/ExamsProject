﻿using Application.Common;
using Domain.Entities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;


namespace Application.Repositories
{
    public class FinishedExamsRepository : Repository<FinishedExams>, IFinishedExamsRepository
    {
        public FinishedExamsRepository(ExamsAppDbContext context) : base(context) { }
    }
}
