using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISignInService
    {
        Task<IActionResult> RedirectUserByEmail(string userEmail);
    }
}