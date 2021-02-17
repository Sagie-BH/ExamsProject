using Application.Data.Teacher;
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
        /// <summary>
        /// Edits Title, Description & Subject. Returns 0 if fails.
        /// </summary>
        /// <param name="examId"></param>
        /// <param name="examHeader"></param>
        /// <returns></returns>
        public async Task<int> EditExamHeader(long examId, ExamHeader examHeader)
        {
            var exam = await unitOfWork.Exams.GetFullExamByIdAsync(examId);
            exam.Title = examHeader.ExamTitle;
            exam.Description = examHeader.ExamDescription;
            exam.ExamSubject.Title = examHeader.SubjectTitle;
            exam.ExamSubject.Description = exam.Description;
            return await unitOfWork.Exams.EditAsync(exam, examId);
        }
        public CreateExamViewModel GetNewExamViewModel(long teacherId)
        {
            return new CreateExamViewModel()
            {
                TeacherId = teacherId,
                ExamId = unitOfWork.Exams.GetCount() + 1
            };
        }
        public async Task<CreateExamViewModel> GetExamViewModelById(long examId)
        {
            var exam = await unitOfWork.Exams.GetFullExamByIdAsync(examId);
            var questionList = new List<ExamQuestion>();

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
                questionList.Add(new ExamQuestion()
                {
                    QuestionText = question.QuestionText,
                    QuestionType = question.QuestionType,
                    QuestionTimeLimit = question.QuestionTimeLimit,
                    AnswerOptions = optionList
                });
            }

            return new CreateExamViewModel()
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
                    IsExamPrivate = exam.IsPrivate,
                    ExamDueDate = exam.DueTime.Value,
                    ExamTimeLimit = exam.TestTimeLimit
                },
                Questions = questionList
            };
        }

        //public async Task<CreateExamViewModel> AddExamHeader(long examId, string title, string description)
        //{
        //    var exam = await unitOfWork.Exams.GetByIdAsync(examId);
        //    if (exam != null)
        //    {
        //        exam.Title = title;
        //        exam.Description = description;

        //        if (await unitOfWork.Exams.EditAsync(exam, examId) > 0)
        //        {

        //        }
        //    }

        //}
    }
}
