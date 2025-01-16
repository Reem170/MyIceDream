using DocumentFormat.OpenXml.Spreadsheet;

namespace MyIceDream.Models
{
    public class Cart
    {

        public int Id { get; set;  }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddOrUpdate(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                Items.Add(new CartItem { ProductId = productId, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        internal void AddItem(int productId, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new CartItem { ProductId = productId, Quantity = quantity });
            }
        } 
    }
}
