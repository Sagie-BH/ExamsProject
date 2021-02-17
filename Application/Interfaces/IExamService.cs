using Application.ViewModels.Teacher;

namespace Application.Interfaces
{
    public interface IExamService
    {
        CreateExamViewModel GetNewExamViewModel(long teacherId);
    }
}