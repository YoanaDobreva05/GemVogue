namespace GemVogue.Models;

using Brands;
using Jewelry;

public class SearchOutputModel
{
    public IEnumerable<JewelDetailsOutputModel> Jewels { get; set; }

    public IEnumerable<BrandDetailsOutputModel> Brands { get; set; }
}
