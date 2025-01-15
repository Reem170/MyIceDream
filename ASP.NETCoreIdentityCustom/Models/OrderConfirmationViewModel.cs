namespace MyIceDream.Models
{
    public class OrderConfirmationViewModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Time { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Comment { get; set; }
        public List<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();
    }

    public class OrderItemViewModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
