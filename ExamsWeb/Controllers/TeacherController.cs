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
        //private readonly ISignInService signInService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
            //this.signInService = signInService;
        }
        public async Task<IActionResult> Main(TeacherMainViewModel viewModel)
        {
            viewModel.MyClasses = await teacherService.GetTeacherClasses(viewModel.TeacherId);
            //if (string.IsNullOrEmpty(viewModel.TeacherName))
            //    return RedirectToAction("SignIn", "Account");
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
    }
}
