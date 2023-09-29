namespace ProductsAndCategories.Business.DTOs.Product
{
    public class ProductWithCategoryViewDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
    }
}
