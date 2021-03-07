using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ExamText : DomainObject
    {
        public int Index { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public AppSize FontSize { get; set; }
        public Alignment Alignment { get; set; }
        public bool Bold { get; set; }
        public bool Underlined { get; set; }
        public bool Italic { get; set; }
    }
}
