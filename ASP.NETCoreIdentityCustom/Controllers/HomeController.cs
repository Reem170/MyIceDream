using MyIceDream.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MyIceDream.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace MyIceDream.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Category = await _context.Categories
                .Include(k => k.Products)
                .FirstOrDefaultAsync();

            return View(Category);
        }
        public async Task<IActionResult> Categories(int id)
        {
            var kategori = await _context.Categories
                .Include(k => k.Products)
                .FirstOrDefaultAsync(k => k.Id == id);

            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        public async Task<IActionResult> Product(int id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> ProductsByCategory(int CategoryId)
        {
            var products = await _context.Products
                .Where(p => p.CategoryId == CategoryId)
                .ToListAsync();

            var Category = await _context.Categories.FindAsync(CategoryId);

            ViewData["KategoriNavn"] = Category?.Name ?? "Ukendt kategori";
            return View(products);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}