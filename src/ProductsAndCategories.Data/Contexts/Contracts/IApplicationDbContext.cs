using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Data.Entities;

namespace ProductsAndCategories.Data.Contexts.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<ProductEntity> Products { get; set; }
        DbSet<CategoryEntity> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
