namespace GemVogue.Models.Brands
{
    public class CreateBrandInputModel
    {
        public IFormFile ProfilePicture { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }
    }
}
