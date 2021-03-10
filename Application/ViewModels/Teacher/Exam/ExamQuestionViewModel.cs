using Application.Data.Teacher.Exam;
using System;
using System.Collections.Generic;

namespace Application.ViewModels.Teacher.Exam
{
    public class ExamQuestionViewModel
    {
        public ExamTextViewModel QuestionText { get; set; }
        public List<ExamAnswer> AnswerOptions { get; set; }
    }
}
