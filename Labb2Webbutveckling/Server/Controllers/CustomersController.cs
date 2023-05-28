using Microsoft.AspNetCore.Mvc;
using DataAccess.Repositories;
using DataAccess.Model;

namespace Labb2Webbutveckling.Server.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;

        public CustomersController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAllAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerModel customer)
        {
            await _customerRepository.AddAsync(customer);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerModel updatedCustomer)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
                return NotFound();

            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.Email = updatedCustomer.Email;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
            customer.Address = updatedCustomer.Address;

            await _customerRepository.UpdateAsync(customer);
            return Ok();
        }

    }
}
