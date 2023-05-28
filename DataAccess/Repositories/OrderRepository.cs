using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository
    {
        private readonly Context _dbContext;

        public OrderRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(OrderModel order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderID == id);
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _dbContext.Orders.Where(o => o.CustomerID == customerId).ToListAsync();
        }

    }
}
