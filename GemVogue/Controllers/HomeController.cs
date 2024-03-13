using GemVogue.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GemVogue.Controllers
{
    using Data;
    using Data.Models;
    using Models.Brands;
    using Models.Jewelry;
    using Models.Messages;

    public class HomeController : Controller
    {
        private readonly GemVogueDbContext data;

        public HomeController(GemVogueDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            var lastFour = this.data.Jewelry
                .Select(j => new JewelDetailsOutputModel()
                {
                    Id = j.Id,
                    Name = j.Name,
                    Description = j.Description,
                    Material = j.Material,
                    CreatedOn = j.CreatedOn,
                    Type = j.Type,
                    ImageUrl = j.ImageUrl,
                    BrandId = j.BrandId,
                    Brand = this.data.Brands
                        .Where(b => b.Id == j.BrandId)
                        .Select(b => new BrandDetailsOutputModel()
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Description = b.Description,
                            ImageUrl = b.ImageUrl
                        })
                        .FirstOrDefault()
                })
                .OrderByDescending(j => j.CreatedOn)
                .Take(4)
                .ToList();

            return View(lastFour);
        }

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
