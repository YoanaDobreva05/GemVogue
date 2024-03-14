namespace GemVogue.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Models.Users;

public class UsersController : Controller
{
    private readonly GemVogueDbContext data;
    private readonly UserManager<User> userManager;

    public UsersController(GemVogueDbContext data, UserManager<User> userManager)
    {
        this.data = data;
        this.userManager = userManager;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Details()
    {
        var user = this.data.Users
            .Where(u => u.Id == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            .Select(u => new UserDetailsOutputModel()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            })
            .Single();

        return View(user);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult All()
    {
        var users = this.data.Users
            .Select(u => new UserDetailsOutputModel()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            })
            .ToList();

        return View(users);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Edit()
    {
        var user = this.data.Users
            .Where(u => u.Id == this.User.FindFirst(ClaimTypes.NameIdentifier).Value)
            .Select(u => new UserDetailsOutputModel()
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            })
            .Single();

        return View(user);
    }

    [HttpPost]
    [Authorize]
    public IActionResult Update(string id, UserDetailsOutputModel input)
    {
        var user = this.data.Users
            .FirstOrDefault(u => u.Id == id);

        user.Name = input.Name;
        user.Email = input.Email;
        user.NormalizedEmail = input.Email.ToUpper();
        user.UserName = input.Email;
        user.UserName = input.Email.ToUpper();

        this.data.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [Authorize]
    public IActionResult Delete(string id)
    {
        var user = this.data.Users
            .FirstOrDefault(u => u.Id == id);

        this.data.Users.Remove(user);
        this.data.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult Add()
        => View();

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Create(UserInputModel input)
    {
        var user = new User
        {
            Name = input.Name,
            UserName = input.Email,
            Email = input.Email,
        };

        await userManager.CreateAsync(user, input.Password);

        return RedirectToAction("All");
    }
}
