using Application.Data.Teacher;
using Application.ViewModels.Teacher;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExamService
    {
        /// <summary>
        /// Edits Title, Description & Subject. Returns 0 if fails.
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="examHeader"></param>
        /// <returns></returns>
        //Task<bool> EditExamHeader(ExamViewModel viewModel);
        Task<ExamViewModel> GetExamViewModelById(long examId);
        ExamViewModel GetNewExamViewModel(long teacherId);
    }
}