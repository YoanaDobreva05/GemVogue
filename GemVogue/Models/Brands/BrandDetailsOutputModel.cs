namespace GemVogue.Models.Brands;

using GemVogue.Data.Models;

public class BrandDetailsOutputModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public IFormFile? Image { get; set; }

    public List<Jewel> Jewels { get; set; } = new ();
}