using MyIceDream.Models;

namespace MyIceDream.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string UserId { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; }

        public int LoyaltyPoints { get; set; }
        public DateTime Time { get; set; }
        public string? Comment { get; set; }

    }
}
