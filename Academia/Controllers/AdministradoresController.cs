using Academia.ViewModels;
using Data.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Academia.Controllers
{
    public class AdministradoresController : Controller
    {
        private readonly IAdministradorRepository _administradorRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdministradoresController(IAdministradorRepository administradorRepository, IHttpContextAccessor httpContextAccessor)
        {
            _administradorRepository = administradorRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.SignOutAsync();
                HttpContext.Session.Clear();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdministradorViewModel administradorViewModel)
        {
            if(! _administradorRepository.AdministradorExiste(administradorViewModel.Email, administradorViewModel.Senha))
            {
                ModelState.AddModelError(string.Empty, "E-mail e/ou senha inválidos");

                return View(administradorViewModel);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, administradorViewModel.Email),
            };

            var userIdentity = new ClaimsIdentity(claims, "login");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(claimsPrincipal);

            HttpContext.Session.SetString("Usuario", administradorViewModel.Email);

            ViewData["Usuario"] = HttpContext.Session.GetString("Usuario");

            return RedirectToAction("Index", "Alunos");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}
