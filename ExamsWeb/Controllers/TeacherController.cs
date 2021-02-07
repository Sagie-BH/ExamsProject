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
        public IActionResult Main(TeacherMainViewModel viewModel)
        {

            return View(viewModel);
        }
        public IActionResult CreateClassRoom()
        {
            return View();
        }
    }
}
