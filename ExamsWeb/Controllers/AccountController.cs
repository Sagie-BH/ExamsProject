using Domain.Entities.UserEntities;
using Infrastructure.Models;
using ExamsWeb.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamsWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Client)]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Client)]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser {
                    UserName = viewModel.Email,
                    Email = viewModel.Email,
                    Teacher = new Teacher()
                    {
                        MonthlySalary = 30000,
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName
                    }
                };
                var result = await userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    //if (signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                    //{
                    //    return RedirectToAction("ListUsers", "Administration");
                    //}

                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Todo", "Todo", user);
                }
                foreach (var err in result.Errors)
                {
                    // Sending sing-up errors to the asp-validation-summary
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }
    }

}
