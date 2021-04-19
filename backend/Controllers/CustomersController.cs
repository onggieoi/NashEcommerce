using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using backend.Repositories.CustomerRepo;
using ViewModelShare.Customer;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private ILogger<ProductsController> _logger;

        public CustomersController(ICustomerRepository _customerRepository,
            ILogger<ProductsController> logger)
        {
            customerRepository = _customerRepository;
            _logger = logger;
        }

        [Authorize("Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetProducts()
        {
            var customers = await customerRepository.GetCustomers();

            return Ok(customers);
        }
    }
}