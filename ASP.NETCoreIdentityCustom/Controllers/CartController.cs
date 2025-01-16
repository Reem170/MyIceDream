using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MyIceDream.Areas.Identity.Data;
using MyIceDream.Models;
using System.Security.Claims;

namespace MyIceDream.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(CartService cartService, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _cartService = cartService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            _cartService.AddToCart(productId, quantity);
            return RedirectToAction("Index", "Cart");
           
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId);
            return RedirectToAction("Index", "Caer");
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }
      

        [HttpPost]
        public IActionResult ConfirmOrder(DateTime time, string comment = "")
        {
            DateTime currentTime = DateTime.Now;

            if (time < currentTime.AddMinutes(15))
            {
                ModelState.AddModelError("Time", "Afhentningstiden skal være mindst 15 minutter ");
                return View("Checkout");
            }

            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var customerName = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                ModelState.AddModelError("", "Der opstod en fejl med brugeroplysningerne.");
                return View("Checkout");
            }

            // Hent kurven og beregn samlet pris
            var cart = _cartService.GetCart();
            var totalPrice = cart.Items.Sum(item => item.Product.Price * item.Quantity);

            var loyaltyPoints = (int)(totalPrice / 100) * 15; // 15 points per 100 kr. i samlet pris

            var existingPoints = _context.Orders
                            .Where(o => o.UserId == userId)
                            .Sum(o => o.LoyaltyPoints);


            loyaltyPoints += existingPoints;

            var order = new Order
            {
                Time = time,
                UserId = userId,
                CustomerName = customerName,
                TotalPrice = totalPrice,
                Comment = comment,
                LoyaltyPoints = loyaltyPoints,
                Items = cart.Items.Select(item => new OrderItem
                {
                    Product = item.Product,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    Price = item.Product.Price
                }).ToList()

            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            _cartService.ClearCart();

            return RedirectToAction("OrderConfirmation", new { orderId = order.Id });
        }

        public IActionResult OrderConfirmation(int orderId)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            var order = _context.Orders
                .Where(o => o.Id == orderId && o.UserId == userId)
                .Include(o => o.Items)
                .ThenInclude(item => item.Product)
                .Select(o => new OrderConfirmationViewModel
                {
                    OrderId = o.Id,
                    CustomerName = o.CustomerName,
                    Time = o.Time,
                    TotalPrice = o.TotalPrice,
                    Comment = o.Comment,
                    Items = o.Items.Select(item => new OrderItemViewModel
                    {
                       ProductName = item.Product.Name,
                        Price = item.Price,
                        Quantity = item.Quantity
                    }).ToList()
                })
                .FirstOrDefault();

            if (order == null)
            {
                return NotFound("Ordren blev ikke fundet.");
            }

            return View(order);
        }


    }

}
