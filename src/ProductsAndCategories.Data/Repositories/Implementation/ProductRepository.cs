using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Data.Contexts.Contracts;
using ProductsAndCategories.Data.Entities;
using ProductsAndCategories.Data.Repositories.Contracts;

namespace ProductsAndCategories.Data.Repositories.Implementation
{
    public class ProductRepository : BaseRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public async Task<IEnumerable<ProductEntity>> GetWithCategoryAsync() =>
            await appContext.Set<ProductEntity>()
           .AsNoTracking()
           .Include(p => p.Category)
           .ToListAsync();

        public async Task<IEnumerable<ProductEntity>> GetByCategoryIdAsync(int categoryId) =>
            await appContext.Set<ProductEntity>()
            .AsNoTracking()
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .ToListAsync();
    }
}
