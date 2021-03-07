using Application.Data.Teacher.Exam;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Teacher.Exam
{
    public class ExamTextViewModel
    {
        [Required]
        public string Text { get; set; }
        public string Color { get; set; }
        [Display(Name = "Font Size:")]
        public AppSize FontSize { get; set; }
        public Alignment Alignment { get; set; }
        public bool Bold { get; set; }
        public bool Underlined { get; set; }
        public bool Italic { get; set; }
        public string IdName { get; set; }
        public ExamAnswer Answer { get; set; }
    }
}
