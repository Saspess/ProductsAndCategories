namespace ProductsAndCategories.Data.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = null!;

        public IEnumerable<ProductEntity> Products { get; set; }
    }
}
