using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    public class AuthController : Controller
    {
        private IIdentityServerInteractionService _interaction;
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;

        public AuthController(
            IIdentityServerInteractionService interaction,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _interaction = interaction;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginAuthModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAuthModel loginVm, string button)
        {
            var context = await _interaction.GetAuthorizationContextAsync(loginVm.ReturnUrl);

            if (button.Equals("cancel"))
            {
                await _interaction.DenyAuthorizationAsync(context, AuthorizationError.AccessDenied);

                return Redirect(context.RedirectUri);
            }

            var result = await _signInManager.PasswordSignInAsync(loginVm.Username, loginVm.Password, false, false);

            if (!result.Succeeded)
            {
                ViewBag.Error = "Invalid Username or Password";
                return View("Login", loginVm);
            }

            ViewBag.Error = null;

            return Redirect(loginVm.ReturnUrl);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterAuthModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterAuthModel RegisterVm, string button)
        {
            if (button.Equals("cancel"))
            {
                return Redirect("~/");
            }

            if (!ModelState.IsValid)
            {
                return View("Register", RegisterVm);
            }

            var user = new IdentityUser(RegisterVm.Username);

            var result = await _userManager.CreateAsync(user, RegisterVm.Password);

            if (!result.Succeeded)
            {
                return View("Register", RegisterVm);
            }

            await _userManager.AddClaimAsync(user, new Claim("testScope", $"{RegisterVm.Username}-testScope"));

            await _signInManager.SignInAsync(user, false);

            return Redirect(RegisterVm.ReturnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();

            var logoutRequest = await _interaction.GetLogoutContextAsync(logoutId);

            // if (string.IsNullOrEmpty(logoutRequest.PostLogoutRedirectUri))
            // {
            //     return RedirectToAction("Index", "Home");
            // }

            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }

    public class LoginAuthModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }

    public class RegisterAuthModel
    {
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public string ReturnUrl { get; set; }
    }
}