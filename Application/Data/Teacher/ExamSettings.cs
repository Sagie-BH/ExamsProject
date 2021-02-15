﻿using Application.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Data.Teacher
{
    public class ExamSettings
    {
        [Required]
        [Display(Name ="Title")]
        public string ExamTitle { get; set; }
        [Display(Name = "Description")]
        public string ExamDescription { get; set; }
        [Display(Name = "Make It Private")]
        public bool IsExamPrivate { get; set; }

        [Display(Name = "Time Limit: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm}")]
        [RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)",
                            ErrorMessage = "Time must be between 00:00 to 23:59")]
        public TimeSpan? ExamTimeLimit { get; set; }

        [ThreeMonthAheadValidation]
        public DateTime ExamDueDate { get; set; }

    }
}
