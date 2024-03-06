using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using GemVogue.Data.Enums;

namespace GemVogue.Data.Models
{
    public class Jewelry
    {
        public int Id { get; set; }

        [DisplayName("Име")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Материал")]
        public string Material { get; set; }

        public DateTime DateOfPosting { get; set; } = DateTime.Now;

        public JewelryType Type { get; set; }

        public string Image { get; set; }

        public int ProducerId { get; set; }

        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
    }
}
