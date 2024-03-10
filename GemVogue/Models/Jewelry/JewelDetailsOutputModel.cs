namespace GemVogue.Models.Jewelry;

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

    public int BrandId { get; set; }

    public Brand Brand { get; set; }
}