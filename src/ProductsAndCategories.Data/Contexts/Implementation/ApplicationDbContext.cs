using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Data.Contexts.Contracts;
using ProductsAndCategories.Data.Entities;
using System.Reflection;

namespace ProductsAndCategories.Data.Contexts.Implementation
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<CategoryEntity> Categories { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
