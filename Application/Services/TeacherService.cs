using Application.Data.Teacher;
using Application.Interfaces;
using Application.ViewModels.Teacher;
using Domain.Entities.Relational;
using Domain.Entities.UserEntities;
using Infrastructure.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var teacher = await unitOfWork.Teachers.GetTeacherById(teacherId);
            var teacherViewModel = new TeacherMainViewModel()
            {
                TeacherName = teacher.ToString(),
                TeacherId = teacher.Id,
            };
            return teacherViewModel;
        }

        public async Task<List<MyClassRoom>> GetTeacherClasses(long teacherId)
        {
            var teacher = await unitOfWork.Teachers.GetTeacherById(teacherId);

            var teacherClasses = new List<MyClassRoom>();
            if(teacher.MyClasses.Any())
            {
                foreach (var classRoom in teacher.MyClasses)
                {
                    teacherClasses.Add(new MyClassRoom()
                    {
                        ClassTitle = classRoom.Title,
                        StudentCount = classRoom.Students.Count,
                        Subject = classRoom.Subject.Title
                    });
                }
            }
            return teacherClasses;
        }
        /// <summary>
        /// Returns false and rollback saving if encounter any exception
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public async Task<bool> SaveNewClassRoom(CreateClassViewModel viewModel)
        {
            var teacher = await unitOfWork.Teachers.GetByIdAsync(viewModel.TeacherId);
            try
            {
                await unitOfWork.Subjects.AddAsync(viewModel.Subject);

                await unitOfWork.ClassRooms.AddAsync(new ClassRoom()
                {
                    Title = viewModel.ClassName,
                    Subject = viewModel.Subject,
                    ClassTeacher = teacher
                });
            }
            catch (Exception ex)
            {
                Exceptions.Add(ex);
                return false;
            }
            // Todo: EmailSender Service - Invitations
            return await unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
