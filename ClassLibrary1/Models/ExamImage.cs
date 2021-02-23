using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ExamImage : DomainObject
    {
        public string ImagePath { get; set; }
#nullable enable
        public ExamText? ImageText { get; set; }
        public string? Desctiption { get; set; }
        public Alignment Alignment { get; set; }
#nullable disable
    }
}
