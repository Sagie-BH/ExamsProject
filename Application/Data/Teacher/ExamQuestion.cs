using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.Teacher
{
    public class ExamQuestion
    {
        public string QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<ExamAnswer> AnswerOptions { get; set; }
        public TimeSpan? QuestionTimeLimit { get; set; }

    }
}
