using Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Data.Teacher.Exam
{
    public class ExamSettings
    {

        [Display(Name = "Make It Private:")]
        public bool IsExamPrivate { get; set; }

        [Display(Name = "Time Limit:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [RegularExpression(@"((0([0-4]))(:[0-5][0-9])(:[0-5][0-9])?)",
                            ErrorMessage = "Time must be between 00:00 to 04:59")]
        public TimeSpan? ExamTimeLimit { get; set; }

        [Display(Name = "Exam Due Date:")]
        public DateTime ExamDueDate { get; set; }

    }
}
