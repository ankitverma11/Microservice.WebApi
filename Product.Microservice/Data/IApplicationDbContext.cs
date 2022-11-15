using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.Microservice.Data
{
	public interface IApplicationDbContext
	{
        DbSet<Entities.Product>? Product { get; set; }

		Task<int> SaveChanges();
	}
}

