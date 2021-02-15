using Application.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SignInService : Controller, ISignInService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ITeacherService teacherService;

        public SignInService(UserManager<AppUser> userManager, ITeacherService teacherService)
        {
            this.userManager = userManager;
            this.teacherService = teacherService;
        }

        public async Task<IActionResult> RedirectUserByEmail(string userEmail)
        {
            var currentUser = await userManager.FindByNameAsync(userEmail);
            if (currentUser != null)
            {
                if (currentUser.TeacherId != null)
                {
                    var teacherViewModel = await teacherService.GetTeacherViewModelById(currentUser.TeacherId.Value);
                    return RedirectToAction("Main", "Teacher", teacherViewModel );
                }
                else
                {
                    // Student
                    return RedirectToAction("Main", "Teacher", currentUser.Student);
                }
            }
            else return RedirectToAction("SignIn", "Account");
        }
    }
}
