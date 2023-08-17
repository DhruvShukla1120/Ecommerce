using System.ComponentModel.DataAnnotations;


namespace Product_Details_Devops.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]

        public string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        public int Qunatity { get; set; }
        public decimal Discount { get; set; }
        public DateTime DateTime { get; set; }

    }
}
