using Application.Data.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Teacher
{
    public class CreateExamViewModel
    {
        public long TeacherId { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string ExamTitle { get; set; }

        [Display(Name = "Description")]
        public string ExamDescription { get; set; }
        public ExamSettings Settings { get; set; }

    }
}
