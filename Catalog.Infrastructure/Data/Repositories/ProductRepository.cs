﻿using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;

namespace Catalog.Infrastructure.Data.Repositories
{
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}