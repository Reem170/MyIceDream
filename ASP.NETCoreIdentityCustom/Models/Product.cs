using Microsoft.EntityFrameworkCore.Query;
using System.ComponentModel;

namespace MyIceDream.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
       
        public bool Availability { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

      
    }
}

