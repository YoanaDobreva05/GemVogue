namespace GemVogue.Controllers;

using Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Models.Users;

public class UsersController : Controller
{
    private readonly GemVogueDbContext data;

    public UsersController(GemVogueDbContext data)
    {
        this.data = data;
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
}
