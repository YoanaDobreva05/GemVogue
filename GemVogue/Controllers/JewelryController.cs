using GemVogue.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GemVogue.Controllers
{
    public class JewelryController : Controller
    {
        private readonly GemVogueDbContext _context;

        public JewelryController(GemVogueDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allJewelry = await _context.Jewelry
                .Include(j => j.Brand).ToListAsync();
            return View(allJewelry);
        }
    }
}
