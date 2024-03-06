namespace GemVogue.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public List<Favorite> Favorites { get; set; } = new List<Favorite>();
    }
}
