namespace GemVogue.Models.Brands;

public class CreateBrandInputModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public IFormFile Image { get; set; }
}