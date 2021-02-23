using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.Teacher.Dtos
{
    public class ExamImageDto
    {
        public ExamTextDto ExamText { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public Alignment Alignment { get; set; }
    }
}
