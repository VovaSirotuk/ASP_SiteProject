using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Numerics;
using Microsoft.AspNetCore.Authentication;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        [ViewData]
        public string title { get; set; }
        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(AppUser model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByEmailAsync(model);
        //        if (user != null)
        //        {
        //            var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
        //            if (result.Succeeded)
        //            {
        //                HttpContext.Session.SetString("UserId", user.Id);
        //                HttpContext.Session.SetString("UserName", user.UserName);
        //                return RedirectToAction("Index", "Home");
        //            }
        //        }
        //        ModelState.AddModelError("", "Invalid login attempt");
        //    }
        //    return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> Register(AppUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.PasswordHash);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
               
        [HttpPost]
        public async Task<IActionResult> Login(AppUser model)
        {
           
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
                var result = await signInManager.PasswordSignInAsync(user, model.PasswordHash, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        AppUser user = new AppUser
        //        {
        //            Email = model.Email,
        //            UserName = model.UserName,
        //        };

        //        var result = await userManager.CreateAsync(user, model.Password!);

        //        if (result.Succeeded)
        //        {
        //            await userManager.AddToRoleAsync(user, "User");
        //            await signInManager.SignInAsync(user, false);
        //            return RedirectToAction("ProfileView", "Profile");
        //        }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }

        //    return View(model);
        //}

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
