using Application.Data.Teacher.Exam;
using System;
using System.Collections.Generic;

namespace Application.ViewModels.Teacher.Exam
{
    public class ExamQuestionViewModel
    {
        public string IdName { get; set; }
        public int Index { get; set; }
        public ExamTextViewModel QuestionText { get; set; }
        public List<ExamAnswer> AnswerOptions { get; set; }
    }
}
