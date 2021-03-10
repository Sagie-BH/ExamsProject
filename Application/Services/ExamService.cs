using Application.Data.Teacher.Exam;
using Application.Interfaces;
using Application.ViewModels.Teacher;
using Application.ViewModels.Teacher.Exam;
using AutoMapper;
using Domain.Entities.ObjectEntities;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExamService : IExamService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AppExam NewExam { get; set; }

        public ExamService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            NewExam = new AppExam();
        }

        public ExamTextViewModel GetTextInputByTypeString(string type)
        {
            var textViewModel = new ExamTextViewModel();
            switch (type)
            {
                case "text":
                    textViewModel.IdName = "text";
                    break;
                case "question":
                    textViewModel.IdName = "question";
                    break;
                default:
                    break;
            }
            return textViewModel;
        }

        //public bool AddExamText(ExamTextViewModel examTextDto)
        //{
        //    var newExamText = mapper.Map<ExamText>(examTextDto);
        //    NewExam.ExamTexts.Add(newExamText);
        //    return true;
        //}


        //public async Task<ExamViewModel> GetExamViewModelById(long examId)
        //{
        //    var exam = await unitOfWork.Exams.GetFullExamByIdAsync(examId);
        //    var questionList = new List<ExamQuestionViewModel>();

        //    foreach (var question in exam.Questions)
        //    {
        //        var optionList = new List<ExamAnswer>();

        //        foreach (var option in question.AnswerOptions)
        //        {
        //            optionList.Add(new ExamAnswer()
        //            {
        //                IsRightAnswer = option.IsRightAnswer,
        //                AnswerText = mapper.Map<ExamTextViewModel>(option.AnswerText)
        //            });
        //        }
        //        questionList.Add(new ExamQuestionViewModel()
        //        {
        //            QuestionText = mapper.Map<ExamTextViewModel>(question.QuestionText),
        //            AnswerOptions = optionList
        //        });
        //    }

        //    return new ExamViewModel()
        //    {
        //        ExamId = exam.Id,
        //        ExamHeader = new ExamHeader()
        //        {
        //            ExamTitle = exam.Title,
        //            ExamDescription = exam.Description,
        //            SubjectTitle = exam.ExamSubject.Title,
        //            SubjectDescription = exam.ExamSubject.Description,
        //        },
        //        Settings = new ExamSettings()
        //        {
        //            IsExamPrivate = exam.IsPrivate.HasValue,
        //            ExamDueDate = exam.DueTime.Value,
        //            ExamTimeLimit = exam.TestTimeLimit
        //        },
        //        Questions = questionList
        //    };
        //}

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
