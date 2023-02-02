using WebApi.Data.Entities;

namespace WebApi.Models
{
    public class CartItemModel
    {
        public ProductEntity? Product { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}
