using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyIceDream.Models
{
    public class ProductIndexViewModel
    {
        public int? SelectedCategoryId { get; set; } // Til dropdown-filtrering
        public IEnumerable<Product> Products { get; set; } // Produkter til visning
        public IEnumerable<SelectListItem> Categories { get; set; }
       
    }

}
