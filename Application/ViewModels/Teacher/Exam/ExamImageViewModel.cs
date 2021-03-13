using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels.Teacher.Exam
{
    public class ExamImageViewModel
    {
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        public Alignment Alignment { get; set; }
        public AppSize ImageSizes { get; set; }
    };
}

