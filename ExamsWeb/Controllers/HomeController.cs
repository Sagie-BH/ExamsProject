using Application.Interfaces;
using ExamsWeb.Models;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ExamsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISignInService signInService;

        public HomeController(ISignInService signInService)
        {
            this.signInService = signInService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if(User.Identity.Name != null)
            {
                return await signInService.RedirectUserByEmail(User.Identity.Name);
            }
            return  View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
