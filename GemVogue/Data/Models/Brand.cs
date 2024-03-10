using System.ComponentModel.DataAnnotations;

namespace GemVogue.Data.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name = "Профилна снимка")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Име")]
        public string FullName { get; set; }

        [Display(Name = "Биография")]
        public string Bio { get; set; }

        public List<Jewel> Jewels { get; set; } = new List<Jewel>();
    }
}
