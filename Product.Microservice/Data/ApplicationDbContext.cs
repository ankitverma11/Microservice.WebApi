using System;
using Microsoft.EntityFrameworkCore;

namespace Product.Microservice.Data
{
	public class ApplicationDbContext : DbContext , IApplicationDbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
		}

        public DbSet<Entities.Product>? Product { get; set; }

        public async Task<int> SaveChanges()
        {
            var productId = 0;
            try
            {
                productId = await base.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               throw ex;
            }
            return productId;
        }
    }
}

