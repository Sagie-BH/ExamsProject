using Application.ViewModels.Teacher.Exam;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExamService
    {
        ExamViewModel GetNewExamViewModel(long teacherId);
        ExamTextViewModel GetTextInputByTypeString(string type);

        //bool AddExamText(ExamTextViewModel examTextDto);
    }
}