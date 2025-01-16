using System.Net;
using MyIceDream.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MyIceDream.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace MyIceDream.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        //[Authorize(Policy = "RequireAdmin")]
        public ActionResult Index()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var isAdmin = _httpContextAccessor.HttpContext?.User.IsInRole("Admin") ?? false;
            var isManager = _httpContextAccessor.HttpContext?.User.IsInRole("Manager") ?? false;

            IQueryable<Order> query = _context.Orders.Include(o => o.Items).ThenInclude(i => i.Product);

            if (isAdmin || isManager)
            {
                // Hvis brugeren er admin eller manager, vis alle ordrer
                var allOrders = query.ToList();
                return View(allOrders);
            }
            else
            {
                // Hvis brugeren er almindelig bruger, vis kun brugerens egne ordrer
                var userOrders = query.Where(o => o.UserId == userId).ToList();
                return View(userOrders);
            }
        }
        public IActionResult Details(int id)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var order = _context.Orders
                .Where(o => o.Id == id && o.UserId == userId)
                .Include(o => o.Items)
                .ThenInclude(item => item.Product)
                .FirstOrDefault();

            if (order == null)
            {
                return NotFound("Ordren blev ikke fundet.");
            }

            return View(order);
        }

        //public IActionResult Create()
        //{

        //    return View();
        //}

        //// POST: Order/Create
        //[HttpPost]

        //public IActionResult Create(Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Orders.Add(order);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(order);
        //}
        public IActionResult Edit(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound("Ordren blev ikke fundet.");
            }
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Update(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound("Ordren blev ikke fundet.");
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Orders.Find(id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}