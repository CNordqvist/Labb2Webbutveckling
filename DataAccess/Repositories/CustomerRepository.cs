using System.Collections.Generic;
using System.Linq;
using DataAccess;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;


public class CustomerRepository
{
    private readonly Context _dbContext;

    public CustomerRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(CustomerModel customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(CustomerModel customer)
    {
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<CustomerModel>> GetAllAsync()
    {
        return await _dbContext.Customers.ToListAsync();
    }

    public async Task<CustomerModel> GetByIdAsync(int id)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerID == id);
    }

    public async Task<IEnumerable<CustomerModel>> SearchByEmailAsync(string email)
    {
        return await _dbContext.Customers.Where(c => c.Email.Contains(email)).ToListAsync();
    }
}
