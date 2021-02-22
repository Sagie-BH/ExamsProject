using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.Data.Teacher.Dtos
{
    public class ExamTextDto
    {
        [Required]
        public string Text { get; set; }
        public string Color { get; set; } = "Black";
        [Range(1, 132)]
        [Display(Name ="Font Size:")]
        public int FontSize { get; set; } = 16;
        public Alignment Alignment { get; set; } = Alignment.Left;
        public bool Bold { get; set; } = false;
        public bool Underlined { get; set; } = false;
        public bool Italic { get; set; } = false;
    }
}
