using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using HrExam.Models;
using HrExam.RegisterViewModel;

namespace HrExam.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> Umanager,SignInManager<User> Smanager)
        {
            userManager = Umanager;
            signInManager = Smanager;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();

        }


        [HttpPost]

        public async Task<IActionResult> Register(registersModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    number = model.number,
                    UserName = model.UserName,
                    SurName = model.SurName,
                    Gender = model.Gender,
                    dateTime = model.dateTime,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
              
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new loginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(loginModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "არასწორი სახელი ან პაროლი");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
