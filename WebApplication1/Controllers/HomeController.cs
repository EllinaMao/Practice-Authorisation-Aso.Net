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
    public class HomeController : Controller
    {
        public readonly IPerson _personRepositories;
        public HomeController(IPerson repo)
        {
            _personRepositories = repo;

        }

        [HttpPost("/Home/login")]
        public async Task<IActionResult> Login(PersonViewModel model)
        {

            var person = _personRepositories.GetByEmail(model.Email);
            if (person != null && person.Password == model.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, person.Email),
                    new Claim(ClaimTypes.Role, person.Role.Name)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction(nameof(Index));

            }
            else
            {
                TempData["Error"] = "Invalid email or password.";
                return View(model);
            }
        }
        [HttpGet("/Home/login")]
        public IActionResult Login()
        {
            return View();
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/Home/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register(PersonViewModel model)
        {
            var person = new Person(model.Email, model.Password, model.Role);


            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
