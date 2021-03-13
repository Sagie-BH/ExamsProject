using Application.Data.Teacher.Exam;
using Domain.Enums;
using System;
using System.Collections.Generic;


namespace Application.ViewModels.Teacher.Exam
{
    public class ExamViewModel
    {
        public long TeacherId { get; set; }
        public ExamHeader ExamHeader { get; set; }
        public ExamSettings Settings { get; set; }
        public List<ExamQuestionViewModel> Questions { get; set; }
        public List<ExamTextViewModel> ExamTexts { get; set; }
        public List<ExamImageViewModel> ExamImages { get; set; }
    }
}
