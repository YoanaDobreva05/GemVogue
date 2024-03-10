using Microsoft.AspNetCore.Identity;

namespace GemVogue.Data.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public List<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
