using GemVogue.Data;
using Microsoft.AspNetCore.Mvc;

namespace GemVogue.Controllers
{
    public class JewelrysController : Controller
    {
        private readonly GemVogueDbContext _context;

        public JewelrysController(GemVogueDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allJewelry = _context.Jewelry.ToList();
            return View(allJewelry);
        }
    }
}
