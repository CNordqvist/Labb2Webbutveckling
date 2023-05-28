using DataAccess.Model;
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

        public void Add(OrderModel order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }

        public IEnumerable<OrderModel> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public OrderModel GetById(int id)
        {
            return _dbContext.Orders.FirstOrDefault(o => o.OrderID == id);
        }

        public IEnumerable<OrderModel> GetOrdersByCustomerId(int customerId)
        {
            return _dbContext.Orders.Where(o => o.CustomerID == customerId).ToList();
        }

    }
}
