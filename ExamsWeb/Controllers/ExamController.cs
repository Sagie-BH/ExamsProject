using Application.Interfaces;
using Application.ViewModels.Teacher;
using Application.ViewModels.Teacher.Exam;
using Microsoft.AspNetCore.Mvc;


namespace ExamsWeb.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService examService;

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }
        [HttpGet]
        public IActionResult Exam(ExamViewModel examViewModel)
        {
            return View(examViewModel);
        }
        [HttpGet]
        public IActionResult CreateExam(long teacherId)
        {
            return RedirectToAction("Exam", new ExamViewModel() { TeacherId = teacherId });
        }
        [HttpPost]
        public IActionResult AddTextInput([FromBody]ExamTextViewModel examText)
        {
            //examService.AddExamText(examText);
            return PartialView("_TextInputTemplate", examText);
        }
        [HttpPost]
        public IActionResult GetTextInput([FromBody]string textInputType)
        {
            var viewModel = examService.GetTextInputByTypeString(textInputType);

            return PartialView("_TextInput", viewModel);
        }
    }
}
