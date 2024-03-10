using GemVogue.Data;
using GemVogue.Models.Brands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GemVogue.Data.Models;
using Microsoft.AspNetCore.Hosting;

namespace GemVogue.Controllers
{
    public class BrandsController : Controller
    {
        private readonly GemVogueDbContext data;
        private readonly IWebHostEnvironment env;

        public BrandsController(
            GemVogueDbContext data,
            IWebHostEnvironment env)
        {
            this.data = data;
            this.env = env;
        }
        
        [HttpGet]
        public IActionResult All()
        {
            var brands = this.data.Brands.ToList();

            return View(brands);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var brand = this.data.Brands
                .Where(b => b.Id == id)
                .Select(b => new BrandDetailsOutputModel()
                {
                    Id = b.Id,
                    FullName = b.FullName,
                    Bio = b.Bio,
                    ProfilePicture = b.ProfilePicture
                })
                .FirstOrDefault();

            return View(brand);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Add()
            => View();

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(CreateBrandInputModel input)
        { 
            using var fileStream = new FileStream(
                Path.Combine(
                    this.env.WebRootPath,
                    "Images",
                    input.ProfilePicture.FileName), 
                FileMode.Create);

            input.ProfilePicture.CopyTo(fileStream);

            var brand = new Brand()
            {
                FullName = input.Name,
                Bio = input.Bio,
                ProfilePicture = @"\Images\" + input.ProfilePicture.FileName,
            };

            this.data.Add(brand);
            this.data.SaveChanges();

            return RedirectToAction("All");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int id)
        {
            var brand = this.data.Brands
                .Where(b => b.Id == id)
                .Select(b => new BrandDetailsOutputModel()
                {
                    Id = b.Id,
                    FullName = b.FullName,
                    Bio = b.Bio,
                    ProfilePicture = b.ProfilePicture
                })
                .FirstOrDefault();

            return View(brand);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Update(BrandDetailsOutputModel input)
        {
            var brand = this.data.Brands
                .Single(b => b.Id == input.Id);

            brand.FullName = input.FullName;
            brand.Bio = input.Bio;

            if (input.ProfilePicture != null)
            {
                
            }

            return RedirectToAction("All");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var brand = this.data.Brands.Single(b => b.Id == id);

            this.data.Brands.Remove(brand);
            this.data.SaveChanges();

            return RedirectToAction("All");
        }
    }
}
