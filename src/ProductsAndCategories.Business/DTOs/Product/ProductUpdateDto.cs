namespace ProductsAndCategories.Business.DTOs.Product
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
    }
}
