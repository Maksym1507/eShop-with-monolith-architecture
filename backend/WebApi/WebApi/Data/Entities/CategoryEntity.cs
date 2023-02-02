namespace WebApi.Data.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = null!;

        public List<ProductEntity> Products { get; set; } = new ();
    }
}
