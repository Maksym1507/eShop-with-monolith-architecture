using WebApi.Data.Entities;

namespace WebApi.Responses
{
    public class OrderProductResponse
    {
        public ProductEntity Product { get; set; } = null!;

        public int Count { get; set; }

        public decimal Total { get; set; }
    }
}
