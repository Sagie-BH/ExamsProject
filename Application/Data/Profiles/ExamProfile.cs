using Application.ViewModels.Teacher.Exam;
using AutoMapper;
using Domain.Entities.ObjectEntities;
using Domain.Models;

namespace Application.Data.Profiles
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            CreateMap<ExamTextViewModel, ExamText>();
            CreateMap<ExamText, ExamTextViewModel>();

            CreateMap<ExamQuestionViewModel, QuestionObject>();

            //CreateMap<ExamImageViewModel, ExamImage>()
            //    .ForMember(vm => vm.ImageSize, e => e.Res)
        }
    }
}
