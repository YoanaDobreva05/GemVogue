namespace GemVogue.Models.Jewelry;

using Brands;
using Data.Enums;
using GemVogue.Data.Models;

public class JewelDetailsOutputModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Material { get; set; }

    public DateTime CreatedOn { get; set; }

    public JewelryType Type { get; set; }

    public string ImageUrl { get; set; }

    public IFormFile? Image { get; set; }

    public bool IsFavorite { get; set; } = false;

    public int BrandId { get; set; }

    public BrandDetailsOutputModel Brand { get; set; }
}