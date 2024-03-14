namespace GemVogue.Controllers;

using Data;
using Data.Enums;
using GemVogue.Data.Models;
using Models.Brands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Jewelry;
using System.Security.Claims;

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
        var jewelry = this.GetJewelry();

        return View(jewelry);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Favorites()
    {
        var favorites = this.data.Favorites
            .Where(f => f.UserId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        var jewelry = new List<JewelDetailsOutputModel>();

        foreach (var favorite in favorites)
        {
            jewelry.Add(this.data.Jewelry
                .Where(j => j.Id == favorite.JewelId)
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
                .FirstOrDefault());
        }

        return View(jewelry);
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddToFavorites(int id)
    {
        var favorite = new Favorite()
        {
            UserId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value,
            JewelId = id
        };

        this.data.Add(favorite);
        this.data.SaveChanges();

        return RedirectToAction("Favorites");
    }

    [HttpPost]
    [Authorize]
    public IActionResult RemoveFromFavorites(int id)
    {
        var favorite = this.data.Favorites
            .FirstOrDefault(f => f.UserId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value && f.JewelId == id);

        this.data.Remove(favorite);
        this.data.SaveChanges();

        return RedirectToAction("Favorites");
    }

    [HttpGet]
    public IActionResult Necklaces()
    {
        var jewelry = this
            .GetJewelry()
            .Where(j => j.Type == JewelryType.Necklace);

        return View("All", jewelry);
    }

    [HttpGet]
    public IActionResult Rings()
    {
        var jewelry = this
            .GetJewelry()
            .Where(j => j.Type == JewelryType.Ring);

        return View("All", jewelry);
    }

    [HttpGet]
    public IActionResult Earrings()
    {
        var jewelry = this
            .GetJewelry()
            .Where(j => j.Type == JewelryType.Earring);

        return View("All", jewelry);
    }

    [HttpGet]
    public IActionResult Bracelets()
    {
        var jewelry = this
            .GetJewelry()
            .Where(j => j.Type == JewelryType.Bracelet);

        return View("All", jewelry);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var jewel = this.data.Jewelry
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

        jewel.Brand = this.data.Brands
            .Where(b => b.Id == jewel.BrandId)
            .Select(b => new BrandDetailsOutputModel()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                ImageUrl = b.ImageUrl
            })
            .FirstOrDefault();

        if (this.User.Identity.IsAuthenticated)
        {
            jewel.IsFavorite = this.data.Favorites.Any(j => j.JewelId == id && j.UserId == this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        return View(jewel);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult Add()
    {
        var model = new CreateJewelInputModel();

        model.Brands = this.data.Brands
            .Select(b => new BrandDetailsOutputModel()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                ImageUrl = b.ImageUrl,
            })
            .ToList();

        return View(model);
    }

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

        var jewel = new Jewel()
        {
            Name = input.Name,
            Description = input.Description,
            Material = input.Material,
            Type = input.Type,
            ImageUrl = @"\Images\" + input.Image.FileName,
            BrandId = input.BrandId
        };

        this.data.Add(jewel);
        this.data.SaveChanges();

        return RedirectToAction("All");
    }

    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public IActionResult Edit(int id)
    {
        var jewel = this.data.Jewelry
            .Where(b => b.Id == id)
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

        return View(jewel);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public IActionResult Update(int id, JewelDetailsOutputModel input)
    {
        var jewel = this.data.Jewelry
            .Single(b => b.Id == id);

        jewel.Name = input.Name;
        jewel.Description = input.Description;
        jewel.Material = input.Material;

        if (input.Image != null)
        {
            using var fileStream = new FileStream(
                Path.Combine(
                    this.env.WebRootPath,
                    "Images",
                    input.Image.FileName),
                FileMode.Create);

            input.Image.CopyTo(fileStream);

            jewel.ImageUrl = @"\Images\" + input.Image.FileName;
        }

        this.data.SaveChanges();

        return RedirectToAction("All");
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(int id)
    {
        var jewel = this.data.Jewelry.Single(j => j.Id == id);

        this.data.Jewelry.Remove(jewel);
        this.data.SaveChanges();

        return RedirectToAction("All");
    }

    private IEnumerable<JewelDetailsOutputModel> GetJewelry() 
        => this.data.Jewelry
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
}