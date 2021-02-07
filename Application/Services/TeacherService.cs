using Application.Interfaces;
using Application.ViewModels.Teacher;
using Infrastructure.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        public List<Exception> Exceptions { get; }


        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        public async Task<TeacherMainViewModel> GetTeacherViewModelById(long teacherId)
        {
            var teacher = await teacherRepository.GetByIdAsync(teacherId);
            var teacherViewModel = new TeacherMainViewModel()
            {
                TeacherName = teacher.ToString(),

            };
            return teacherViewModel;
        }
    }
}
