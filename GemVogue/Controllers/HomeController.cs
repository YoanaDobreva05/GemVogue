using GemVogue.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GemVogue.Controllers
{
    using Data;
    using Data.Models;
    using Models.Messages;

    public class HomeController : Controller
    {
        private readonly GemVogueDbContext data;

        public HomeController(GemVogueDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index() 
            => View();

        public IActionResult About() 
            => View();

        public IActionResult Contacts() 
            => View();

        [HttpPost]
        public IActionResult Contact(CreateMessageInputModel input)
        {
            var message = new Message()
            {
                Name = input.Name,
                Email = input.Email,
                Subject = input.Subject,
                Content = input.Content
            };

            this.data.Add(message);
            this.data.SaveChanges();

            return RedirectToAction("Contacts");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
