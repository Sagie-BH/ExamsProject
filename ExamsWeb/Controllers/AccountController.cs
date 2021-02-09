using Domain.Entities.UserEntities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.ViewModels.Account;
using Application.Interfaces;
using Application.Services;

namespace ExamsWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ISignInService signInService;

        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 ISignInService signInService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.signInService = signInService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Client)]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);

                if (result.Succeeded)
                {
                    return await signInService.RedirectUserByEmail(viewModel.Email);

                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(viewModel);
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
                var user = new AppUser
                {
                    UserName = viewModel.Email,
                    Email = viewModel.Email,
                    Teacher = new Teacher()
                    {
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
                    return RedirectToAction("Index", "Teacher", user);
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
            return RedirectToAction("Index", "Home");
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
