namespace ProductsAndCategories.Business.DTOs.Product
{
    public class ProductCreateDto
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
    }
}
