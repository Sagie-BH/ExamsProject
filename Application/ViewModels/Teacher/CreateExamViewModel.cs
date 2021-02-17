using Application.Data.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Teacher
{
    public class CreateExamViewModel
    {
        public CreateExamViewModel()
        {
            Settings = new ExamSettings()
            {
                ExamDueDate = DateTime.Now.Date,
                ExamTimeLimit = TimeSpan.Zero
            };
        }
        public long ExamId { get; set; }
        public long TeacherId { get; set; }
        public ExamSettings Settings { get; set; }
        public List<ExamQuestion> Questions { get; set; }
        public ExamHeader ExamHeader { get; set; }

        //[Required]
        //public string ExamTitle { get; set; }
        //[Required]
        //public string ExamDescription { get; set; }
        //[Required]
        //public string SubjectTitle { get; set; }
        //[Required]
        //public string SubjectDescription { get; set; }
    }
}
