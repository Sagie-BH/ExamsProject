using Application.Data.Teacher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Teacher
{
    public class CreateExamViewModel
    {
        public string TeacherId { get; set; }
        public ExamSettings Settings { get; set; }
    }
}
