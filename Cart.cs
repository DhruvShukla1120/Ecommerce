using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string productName { get; set; }
        public decimal rate { get; set; }
        public int quantity { get; set; }
        public decimal totalprice { get; set; } 
    }
}
