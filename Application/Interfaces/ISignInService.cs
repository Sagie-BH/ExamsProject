using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISignInService
    {
        Task<IActionResult> RedirectUserByEmail(string userEmail);
    }
}