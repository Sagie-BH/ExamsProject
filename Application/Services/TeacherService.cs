using Application.Interfaces;
using Application.ViewModels.Teacher;
using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
using Infrastructure.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITeacherRepository teacherRepository;
        private readonly IClassRoomRepository classRoomRepository;
        private readonly ISubjectRepository subjectRepository;

        public List<Exception> Exceptions { get; }


        public TeacherService(IUnitOfWork unitOfWork, ITeacherRepository teacherRepository,
            IClassRoomRepository classRoomRepository,
            ISubjectRepository subjectRepository)
        {
            this.unitOfWork = unitOfWork;
            this.teacherRepository = teacherRepository;
            this.classRoomRepository = classRoomRepository;
            this.subjectRepository = subjectRepository;
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

        public async Task<IActionResult> SaveNewClassRoom(CreateClassViewModel viewModel)
        {
            var teacher = await teacherRepository.GetByIdAsync(viewModel.TeacherId);
            foreach (var subject in viewModel.Subjects)
            {
                try
                {
                    await subjectRepository.AddAsync(subject);
                }
                catch (Exception ex)
                {
                    Exceptions.Add(ex);
                    // Handle ex page
                }
            }
            try
            {
                await classRoomRepository.AddAsync(new ClassRoom()
                {
                    Title = viewModel.ClassName,
                    Subjects = viewModel.Subjects,
                    ClassTeacher = teacher
                });
            }
            catch (Exception ex)
            {
                Exceptions.Add(ex);
                // Handle ex page
            }
        }
    }
}
