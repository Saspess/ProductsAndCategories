using ProductsAndCategories.Data.Entities;

namespace ProductsAndCategories.Data.Repositories.Contracts
{
    public interface IProductRepository : IBaseRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetWithCategoryAsync();
        Task<IEnumerable<ProductEntity>> GetByCategoryIdAsync(int categoryId);
    }
}
