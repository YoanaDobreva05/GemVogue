namespace GemVogue.Models.Jewelry;

using Data.Enums;

public class CreateJewelInputModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Material { get; set; }

    public JewelryType Type { get; set; }

    public int BrandId { get; set; }

    public IFormFile Image { get; set; }
}