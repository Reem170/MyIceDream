namespace MyIceDream.Models
{
    public class CartItem
    {
       public int Id { get; set; }
       public int ProductId { get; set; } // FK
       public Product Product { get; set; } 
       public Cart Cart { get; set; } 
       public int Quantity { get; set; }
    }
}
