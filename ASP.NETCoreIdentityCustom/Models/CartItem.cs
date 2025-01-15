namespace MyIceDream.Models
{
    public class CartItem
    {
       public int Id { get; set; }
       public int ProductId { get; set; } // FK
       public Product Product { get; set; } // Navigation
       public Cart Cart { get; set; } // Navigation
       public int Quantity { get; set; }
    }
}
