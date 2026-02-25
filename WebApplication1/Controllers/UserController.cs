using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public readonly IPerson _personRepositories;
        public UserController(IPerson repo)
        {
            _personRepositories = repo;

        }
        [Authorize]
        public IActionResult Profile()
        {
            var userEmail = User.Identity.Name;
            var person = _personRepositories.GetByEmail(userEmail);

            return View(person);
        }
    }
}
