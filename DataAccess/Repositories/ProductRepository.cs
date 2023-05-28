using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductRepository
    {
        private readonly Context _dbContext;

        public ProductRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(ProductModel product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductModel product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(ProductModel product)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
        }

        public async Task<IEnumerable<ProductModel>> SearchByNameAsync(string searchQuery)
        {
            return await _dbContext.Products.Where(p => p.ProductName.Contains(searchQuery)).ToListAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetDiscontinuedProductsAsync()
        {
            return await _dbContext.Products.Where(p => !p.Status).ToListAsync();
        }
    }
}
