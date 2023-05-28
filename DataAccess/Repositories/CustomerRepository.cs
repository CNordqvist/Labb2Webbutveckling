using System.Collections.Generic;
using System.Linq;
using DataAccess;
using DataAccess.Model;


    public class CustomerRepository
    {
        private readonly Context _dbContext;

        public CustomerRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(CustomerModel customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public void Update(CustomerModel customer)
        {
            _dbContext.Customers.Update(customer);
            _dbContext.SaveChanges();
        }

        public void Remove(CustomerModel customer)
        {
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }

        public IEnumerable<CustomerModel> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public CustomerModel GetById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.CustomerID == id);
        }

        public IEnumerable<CustomerModel> SearchByEmail(string email)
        {
            return _dbContext.Customers.Where(c => c.Email.Contains(email)).ToList();
        }
    }
