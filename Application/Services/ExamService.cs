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

        public bool SaveExamToServer(ExamViewModel viewModel)
        {


            return true;
        }

    }
}
