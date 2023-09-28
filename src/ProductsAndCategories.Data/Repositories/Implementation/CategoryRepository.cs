using ProductsAndCategories.Data.Contexts.Contracts;
using ProductsAndCategories.Data.Entities;
using ProductsAndCategories.Data.Repositories.Contracts;

namespace ProductsAndCategories.Data.Repositories.Implementation
{
    public class CategoryRepository : BaseRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }
    }
}
