using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Application.Data.Teacher.Exam
{
    public class ExamQuestion
    {
        public ExamText QuestionText { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<ExamAnswer> AnswerOptions { get; set; }
        public TimeSpan? QuestionTimeLimit { get; set; }

    }
}
