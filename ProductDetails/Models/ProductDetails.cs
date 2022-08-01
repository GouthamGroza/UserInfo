using System.ComponentModel.DataAnnotations;

namespace ProductDetails.Models
{
    public class ProductDetail
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public int Id { get; set; }
    }
}
