using Application.Interfaces;
using Application.ViewModels.Teacher;
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
        public List<Exception> Exceptions { get; }

        public TeacherService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<TeacherMainViewModel> GetTeacherViewModelById(long teacherId)
        {
            var teacher = await unitOfWork.Teachers.GetByIdAsync(teacherId);
            var teacherViewModel = new TeacherMainViewModel()
            {
                TeacherName = teacher.ToString(),
            };
            return teacherViewModel;
        }

        public async Task<bool> SaveNewClassRoom(CreateClassViewModel viewModel)
        {
            var teacher = await unitOfWork.Teachers.GetByIdAsync(viewModel.TeacherId);
            foreach (var subject in viewModel.Subjects)
            {
                try
                {
                    await unitOfWork.Subjects.AddAsync(subject);
                }
                catch (Exception ex)
                {
                    //Add sql ex
                    Exceptions.Add(ex);
                    // Handle ex page
                    return false;
                }
            }
            try
            {
                await unitOfWork.ClassRooms.AddAsync(new ClassRoom()
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
                return false;
            }
            return await unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
