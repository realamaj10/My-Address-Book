using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using address_bk.Models;

namespace address_bk.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private bool IsRegister;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Route("Account/Login")]
        public IActionResult Login()
        {
            TempData["Login"] = "false";
            return View();
        }

        [HttpPost]
        [Route("Account/Login")]
        [ActionName("Login")]
        public async Task<IActionResult> ValidateLogin(Auth login)
        {
            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(login.UserName);

                if (!String.IsNullOrEmpty(Convert.ToString(user)))
                {
                    var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "BookContacts");
                    }
                    else
                    {
                        TempData["ErrorMessagePass"] = "Invalid Password.";
                        return View();
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Invalid UserName.";
                    return View();
                }
            }
            TempData["Login"] = "true";
            return View();
        }

        [HttpGet]
        [Route("Auth/Register")]
        [ActionName("UserRegister")]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        [ActionName("UserRegister")]
        [Route("Auth/Register")]
        public async Task<IActionResult> VaidateRegister(User bk_user)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = bk_user.Name,
                    Email = bk_user.EmailAddr,

                };

                var result = await _userManager.CreateAsync(user, bk_user.Password);

                if (result.Succeeded)
                {
                    IsRegister = true;
                }
                else
                {
                    var Identityerror = result.Errors.ToList();
                    foreach (IdentityError error in Identityerror)
                    {
                        TempData["ErrorMessage"] = error.Code + ". " + error.Description;
                    }

                }

            }
            if (IsRegister)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        [HttpPost]
        [Route("Auth/Logout")]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            TempData["Login"] = "false";
            return RedirectToAction("Login");
        }
    }
}
