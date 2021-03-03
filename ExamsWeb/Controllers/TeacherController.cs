using Application.Interfaces;
using Application.ViewModels.Teacher;
using Application.ViewModels.Teacher.Exam;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamsWeb.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }
        public async Task<IActionResult> Main(TeacherMainViewModel viewModel)
        {
            viewModel.MyClasses = await teacherService.GetTeacherClasses(viewModel.TeacherId);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateClassRoom(long teacherId)
        {
            var viewModel = new CreateClassViewModel()
            {
                TeacherId = teacherId
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClassRoom(CreateClassViewModel viewModel)
        {
            if(!await teacherService.SaveNewClassRoom(viewModel))
            {
                var teacherViewModel = await teacherService.GetTeacherViewModelById(viewModel.TeacherId);
                return RedirectToAction("Main","Teacher", teacherViewModel);
            }
            var a = teacherService.Exceptions;
            return NotFound();
        }
        public IActionResult CreateExam(long teacherId)
        {
            var viewModel = new ExamViewModel()
            {
                TeacherId = teacherId
            };
            return View(viewModel);
        }
    }
}
