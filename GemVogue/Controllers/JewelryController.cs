namespace GemVogue.Controllers;

using Data;
using GemVogue.Data.Models;
using Models.Brands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Jewelry;

public class JewelryController : Controller
{
    private readonly GemVogueDbContext data;
    private readonly IWebHostEnvironment env;

    public JewelryController(
        GemVogueDbContext data,
        IWebHostEnvironment env)
    {
        this.data = data;
        this.env = env;
    }

    [HttpGet]
    public IActionResult All()
    {
        var jewelry = this.data.Jewelry
            .Select(j => new JewelDetailsOutputModel()
            {
                Id = j.Id,
                Name = j.Name,
                Description = j.Description,
                Material = j.Material,
                CreatedOn = j.CreatedOn,
                Type = j.Type,
                ImageUrl = j.ImageUrl,
                BrandId = j.BrandId
            })
            .ToList();

        return View(jewelry);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var brand = this.data.Jewelry
            .Where(j => j.Id == id)
            .Select(j => new JewelDetailsOutputModel()
            {
                Id = j.Id,
                Name = j.Name,
                Description = j.Description,
                Material = j.Material,
                CreatedOn = j.CreatedOn,
                Type = j.Type,
                ImageUrl = j.ImageUrl,
                BrandId = j.BrandId
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
    public IActionResult Create(CreateJewelInputModel input)
    {
        using var fileStream = new FileStream(
            Path.Combine(
                this.env.WebRootPath,
                "Images",
                input.Image.FileName),
            FileMode.Create);

        input.Image.CopyTo(fileStream);

        var brand = new Brand()
        {
            Name = input.Name,
            Description = input.Description,
            ImageUrl = @"\Images\" + input.Image.FileName,
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
                Name = b.Name,
                Description = b.Description,
                ImageUrl = b.ImageUrl
            })
            .FirstOrDefault();

        return View(brand);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public IActionResult Update(int id, BrandDetailsOutputModel input)
    {
        var brand = this.data.Brands
            .Single(b => b.Id == id);

        brand.Name = input.Name;
        brand.Description = input.Description;

        if (input.Image != null)
        {
            using var fileStream = new FileStream(
                Path.Combine(
                    this.env.WebRootPath,
                    "Images",
                    input.Image.FileName),
                FileMode.Create);

            input.Image.CopyTo(fileStream);

            brand.ImageUrl = @"\Images\" + input.Image.FileName;
        }

        this.data.SaveChanges();

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