﻿using Application.Common;
using Domain.Entities.ObjectEntities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;

namespace Application.Repositories
{
    public class QuestionObjectRepository : Repository<QuestionObject>, IQuestionObjectRepository
    {
        public QuestionObjectRepository(ExamsAppDbContext context) : base(context) { }
    }
}
