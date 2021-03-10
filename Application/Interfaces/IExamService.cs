using Application.ViewModels.Teacher.Exam;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExamService
    {
        ExamTextViewModel GetTextInputByTypeString(string type);
    }
}