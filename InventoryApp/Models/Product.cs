using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Product ID is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name is required.")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public required decimal Price { get; set; }
        [Required(ErrorMessage = "Stock quantity is required.")]
        public required int Quantity { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}