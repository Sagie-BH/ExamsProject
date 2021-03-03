using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ExamImage : DomainObject
    {
        public int Index { get; set; }
        public string ImagePath { get; set; }
        public string ImageSize { get; set; }
        public Alignment Alignment { get; set; } = Alignment.Center;
    }
}
