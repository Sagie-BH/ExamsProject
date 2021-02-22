using Application.Interfaces;
using Application.ViewModels.Teacher;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return RedirectToAction("Exam", examService.GetNewExamViewModel(teacherId));
        }

    }
}
