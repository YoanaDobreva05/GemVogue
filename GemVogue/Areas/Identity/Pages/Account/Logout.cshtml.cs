﻿using GemVogue.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GemVogue.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
