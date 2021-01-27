using Domain.Entities.ObjectEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exams.Helpers
{
    public class QuestionObjectBuilder
    {
        private readonly QuestionObject question;

        public QuestionObjectBuilder(QuestionObject _question)
        {
            question = _question;
        }

        public void ChangeQuestionTitle(string title)
        {
            question.Title = title;
        }
    }
}
