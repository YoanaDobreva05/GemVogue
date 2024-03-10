using GemVogue.Data.Models;

namespace GemVogue.Models.Brands
{
    public class BrandDetailsOutputModel
    {
        public int Id { get; set; }

        public string ProfilePicture { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }

        public List<Jewel> Jewels { get; set; } = new List<Jewel>();
    }
}
