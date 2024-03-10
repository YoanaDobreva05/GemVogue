namespace GemVogue.Data.Models;

using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
{
    public string Name { get; set; }

    public List<Favorite> Favorites { get; set; } = new ();
}