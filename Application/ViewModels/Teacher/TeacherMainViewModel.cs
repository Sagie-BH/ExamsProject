using Application.Data.Teacher;
using Application.ViewModels.Teacher.Exam;
using System.Collections.Generic;

namespace Application.ViewModels.Teacher
{
    public class TeacherMainViewModel
    {
        public long TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<MyClassRoom> MyClasses { get; set; }

        public List<NewPublicExams> TestsArchive { get; set; }

        public List<LatestGrades> StudentGrades { get; set; }

    }
}
