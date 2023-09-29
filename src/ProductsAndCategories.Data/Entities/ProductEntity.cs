namespace ProductsAndCategories.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Price { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
