using Application.Data.Teacher;
using Application.Data.Teacher.Dtos;
using Application.Data.Teacher.Exam;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels.Teacher
{
    public class ExamViewModel
    {
        public ExamViewModel()
        {
            Settings = new ExamSettings()
            {
                ExamDueDate = DateTime.Now.Date,
                ExamTimeLimit = TimeSpan.Zero
            };
        }
        public long ExamId { get; set; }
        public long TeacherId { get; set; }
        public Alignment Alignment { get; set; }
        public ExamHeader ExamHeader { get; set; }
        public ExamSettings Settings { get; set; }
        public List<ExamQuestion> Questions { get; set; }
        public List<ExamTextDto> ExamTexts { get; set; }
        public List<ExamImage> ExamImages { get; set; }
    }
}
