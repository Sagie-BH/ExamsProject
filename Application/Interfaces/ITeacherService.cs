using Application.Data.Teacher;
using Application.ViewModels.Teacher;
using Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITeacherService
    {
        List<Exception> Exceptions { get; }

        Task<List<MyClassRoom>> GetTeacherClasses(long teacherId);
        Task<TeacherMainViewModel> GetTeacherViewModelById(long teacherId);
        Task<bool> SaveNewClassRoom(CreateClassViewModel viewModel);
    }
}
