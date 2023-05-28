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

        public void Add(ProductModel product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public void Update(ProductModel product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public void Remove(ProductModel product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public ProductModel GetById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductID == id);
        }

        public IEnumerable<ProductModel> SearchByNameOrNumber(string searchQuery)
        {
            return _dbContext.Products.Where(p => p.ProductName.Contains(searchQuery) || p.ProductNumber.Contains(searchQuery)).ToList();
        }

        public IEnumerable<ProductModel> GetDiscontinuedProducts()
        {
            return _dbContext.Products.Where(p => p.Status == false).ToList();
        }
    }
}
