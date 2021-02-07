using Application.ViewModels.Teacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITeacherService
    {
        List<Exception> Exceptions { get; }

        Task<TeacherMainViewModel> GetTeacherViewModelById(long teacherId);

    }
}
