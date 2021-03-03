
using Application.ViewModels.Teacher.Exam;

namespace Application.Data.Teacher.Exam
{
    public class ExamAnswer
    {
        public bool IsRightAnswer { get; set; }
        public ExamTextViewModel AnswerText { get; set; }
    }
}