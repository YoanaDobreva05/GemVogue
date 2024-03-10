using System.ComponentModel;
using GemVogue.Data.Enums;

namespace GemVogue.Data.Models
{
    public class Jewel
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Материал")]
        public string Material { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public JewelryType Type { get; set; }

        public string Image { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public List<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
