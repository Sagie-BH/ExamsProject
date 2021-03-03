using Application.ViewModels.Teacher.Exam;
using AutoMapper;
using Domain.Models;

namespace Application.Data.Profiles
{
    public class ExamTextProfile : Profile
    {
        public ExamTextProfile()
        {
            CreateMap<ExamTextViewModel, ExamText>();
            CreateMap<ExamText, ExamTextViewModel>();
        }
    }
}
