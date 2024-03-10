namespace GemVogue.Data.Models;

public class Favorite
{
    public int JewelId { get; set; }

    public Jewel Jewel { get; set; }

    public string UserId { get; set; }

    public User User { get; set; }
}