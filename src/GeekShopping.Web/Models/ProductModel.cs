using System.ComponentModel;

namespace GeekShopping.Web.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }
    }
}
