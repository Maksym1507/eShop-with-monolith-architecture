namespace WebApi.Data.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public CategoryEntity? Category { get; set; }

        public string Title { get; set; } = null!;

        public string? Img { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string Consist { get; set; } = null!;

        public List<OrderProductEntity> OrderProducts { get; set; } = new ();
    }
}