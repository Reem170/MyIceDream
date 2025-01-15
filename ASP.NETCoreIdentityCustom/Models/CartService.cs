using Microsoft.AspNetCore.Http;
using MyIceDream.Areas.Identity.Data;

namespace MyIceDream.Models
{
    public class CartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;

        public CartService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        // Hent eller opret en kurv i sessionen
        public Cart GetCart()
        {
            var cart = _httpContextAccessor.HttpContext.Session.Get<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();
                _httpContextAccessor.HttpContext.Session.Set("Cart", cart);
            }

            foreach (var item in cart.Items)
            {
                item.Product = _context.Products.Find(item.ProductId);
            }
            return cart;
        }

        // Tilføj en vare til kurven
        public void AddToCart(int productId, int quantity)
        {
            var cart = GetCart();
            cart.AddItem(productId, quantity);
            //cart.AddOrUpdate(productId, quantity);
            _httpContextAccessor.HttpContext.Session.Set("Cart", cart);
        }

        //internal void AddToCart(Product product, int quantity)
        //{
        //    throw new NotImplementedException();
        //}

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();

            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
            _httpContextAccessor.HttpContext.Session.Set("Cart", cart);
        }

        internal void ClearCart()
        {
            _httpContextAccessor.HttpContext.Session.Remove("Cart");
            //var cart = GetCart();
            //cart.Items.Clear();
            //SaveCart(cart);
        }
    }

}
