using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ExamImage : DomainObject
    {
        public string ImagePath { get; set; }
#nullable enable
        public string? Desctiption { get; set; }
#nullable disable
    }
}
