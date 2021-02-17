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
        public IActionResult CreateExam(long teacherId)
        {
            return View(examService.GetNewExamViewModel(teacherId));
        }
        public IActionResult SaveHeader(CreateExamViewModel viewModel)
        {
            var a = viewModel;
            return View();
        }
    }
}
