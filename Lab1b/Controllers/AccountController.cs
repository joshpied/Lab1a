// I, Joshua Piedimonte, student number 000746786, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1b.Data;
using Lab1b.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab1b.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _roleManager = RoleManager;
        }

        public async Task<IActionResult> SeedRoles()
        {
            // Create users
            ApplicationUser user1 = new ApplicationUser
            {
                Email = "josh@pied.com",
                UserName = "josh@pied.com",
                FirstName = "Josh",
                LastName = "Piedimonte",
                BirthDate = new DateTime(1994, 7, 23)
            };
            ApplicationUser user2 = new ApplicationUser
            {
                Email = "test@test.com",
                UserName = "test@test.com",
                FirstName = "Test",
                LastName = "Man",
                BirthDate = new DateTime(1991, 9, 12)
            };
            IdentityResult result = await _userManager.CreateAsync(user1, "Mohawk1!");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            result = await _userManager.CreateAsync(user2, "Mohawk1!");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new user" });

            // Create roles
            result = await _roleManager.CreateAsync(new IdentityRole("Staff"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });

            result = await _roleManager.CreateAsync(new IdentityRole("Manager"));
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to add new role" });

            // Assign roles to users
            result = await _userManager.AddToRoleAsync(user1, "Staff");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new role" });

            result = await _userManager.AddToRoleAsync(user2, "Manager");
            if (!result.Succeeded)
                return View("Error", new ErrorViewModel { RequestId = "Failed to assign new role" });


            return RedirectToAction("Index", "Home");
        }
    }
}