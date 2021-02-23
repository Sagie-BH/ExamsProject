using Application.Data.Teacher;
using Application.Data.Teacher.Exam;
using Application.Interfaces;
using Application.ViewModels.Teacher;
using Domain.Entities.ObjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ExamViewModel GetNewExamViewModel(long teacherId)
        {
            return new ExamViewModel()
            {
                TeacherId = teacherId,
                ExamId = unitOfWork.Exams.GetCount() + 1
            };
        }

        public async Task<ExamViewModel> GetExamViewModelById(long examId)
        {
            var exam = await unitOfWork.Exams.GetFullExamByIdAsync(examId);
            var questionList = new List<ExamQuestionDto>();

            foreach (var question in exam.Questions)
            {
                var optionList = new List<ExamAnswer>();

                foreach (var option in question.AnswerOptions)
                {
                    optionList.Add(new ExamAnswer()
                    {
                        IsRightAnswer = option.IsRightAnswer,
                        AnswerText = option.AnswerText
                    });
                }
                questionList.Add(new ExamQuestionDto()
                {
                    QuestionText = question.QuestionText,
                    QuestionType = question.QuestionType,
                    QuestionTimeLimit = question.QuestionTimeLimit,
                    AnswerOptions = optionList
                });
            }

            return new ExamViewModel()
            {
                ExamId = exam.Id,
                ExamHeader = new ExamHeader()
                {
                    ExamTitle = exam.Title,
                    ExamDescription = exam.Description,
                    SubjectTitle = exam.ExamSubject.Title,
                    SubjectDescription = exam.ExamSubject.Description,
                },
                Settings = new ExamSettings()
                {
                    IsExamPrivate = exam.IsPrivate.HasValue,
                    ExamDueDate = exam.DueTime.Value,
                    ExamTimeLimit = exam.TestTimeLimit
                },
                Questions = questionList
            };
        }

        //public async Task<bool> EditExamHeader(ExamViewModel viewModel)
        //{
        //    var exam = await unitOfWork.Exams.GetFullExamByIdAsync(viewModel.ExamId);
        //    if (exam == null)
        //    {
        //        exam = await unitOfWork.Exams.CreateNewExamAsync();
        //    }
        //    var newSubjectId = await unitOfWork.Subjects.AddAsync(new Subject()
        //    {
        //        Title = viewModel.ExamHeader.SubjectTitle,
        //        Description = viewModel.ExamHeader.SubjectDescription
        //    });
        //    exam.Title = viewModel.ExamHeader.ExamTitle;
        //    exam.Description = viewModel.ExamHeader.ExamDescription;
        //    exam.ExamSubject = await unitOfWork.Subjects.GetByIdAsync(newSubjectId);

        //    return await unitOfWork.Exams.EditAsync(exam, exam.Id) > 0;
        //}

    }
}
