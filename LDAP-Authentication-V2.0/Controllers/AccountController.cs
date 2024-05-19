using Microsoft.AspNetCore.Mvc;
using LDAP_Authentication_V2.Services;
using LDAP_Authentication_V2.Models;

namespace LDAP_Authentication_V2.Controllers
{
    public class AccountController : Controller
    {
        private readonly LdapAuthenticationService _ldapAuthService;

        public AccountController(LdapAuthenticationService ldapAuthService)
        {
            _ldapAuthService = ldapAuthService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isAuthenticated = _ldapAuthService.Authenticate(model.Username, model.Password);
                if (isAuthenticated)
                {
                    // Authentication successful, set session or cookie and redirect
                    HttpContext.Session.SetString("User", model.Username);
                    return RedirectToAction("Privacy", "Home");
                }

                // Authentication failed, show error
                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login");
        }
    }
}
