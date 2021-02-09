using Application.Interfaces;
using Application.ViewModels.Teacher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Main(TeacherMainViewModel viewModel)
        {

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateClassRoom(long teacherId)
        {
            CreateClassViewModel viewModel = new CreateClassViewModel()
            {
                TeacherId = teacherId
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateClassRoom(CreateClassViewModel viewModel)
        {
            var a = viewModel;
            return View();
        }
    }
}
