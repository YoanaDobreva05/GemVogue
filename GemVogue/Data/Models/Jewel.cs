namespace GemVogue.Data.Models;

using Enums;


public class Jewel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Material { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public JewelryType Type { get; set; }

    public string ImageUrl { get; set; }

    public int BrandId { get; set; }

    public Brand Brand { get; set; }

    public List<Favorite> Favorites { get; set; } = new ();
}