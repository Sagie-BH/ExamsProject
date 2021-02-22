using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Data.Teacher.Exam
{
    public class ExamHeader
    {
        [Required]
        public string ExamTitle { get; set; }
        [Required]
        public string ExamDescription { get; set; }
        [Required]
        public string SubjectTitle { get; set; }
        [Required]
        public string SubjectDescription { get; set; }
    }
}
