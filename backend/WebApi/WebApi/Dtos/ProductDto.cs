namespace WebApi.View_Models
{
    public class ProductDto
    {
        public int CategoryId { get; set; }

        public string? Title { get; set; }

        public string? Img { get; set; }

        public decimal Price { get; set; }

        public double Weight { get; set; }

        public string? Consist { get; set; }
    }
}
