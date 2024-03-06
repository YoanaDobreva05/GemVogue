using GemVogue.Data;
using Microsoft.AspNetCore.Mvc;

namespace GemVogue.Controllers
{
    public class ProducersController : Controller
    {
        private readonly GemVogueDbContext _context;

        public ProducersController(GemVogueDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Producers.ToList();
            return View(data);
        }
    }
}
