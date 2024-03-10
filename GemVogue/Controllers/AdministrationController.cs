namespace GemVogue.Controllers;

using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Messages;

public class AdministrationController : Controller
{
    private readonly GemVogueDbContext data;

    public AdministrationController(GemVogueDbContext data)
    {
        this.data = data;
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult Messages()
    {
        var messages = this.data.Messages
            .Select(m => new MessageDetailsOutputModel() 
            {
                Id = m.Id,
                Name = m.Name,
                Email = m.Email,
                Subject = m.Subject,
                Content = m.Content
            })
            .ToList();

        return View(messages);
    }

    public IActionResult DeleteMessage(int id)
    {
        var message = this.data.Messages.Single(m => m.Id == id);

        this.data.Remove(message);
        this.data.SaveChanges();

        return RedirectToAction("Messages");
    }
}
