using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Configs;
using Microsoft.AspNetCore.Identity;
using ViewModelShare.Customer;

namespace backend.Repositories.CustomerRepo
{
    public class CustomerRepository : ICustomerRepository
    {
        private IMapper _mapper;
        private UserManager<IdentityUser> _userManager;

        public CustomerRepository(IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<CustomerResponse>> GetCustomers()
        {
            var customersIdentity = await _userManager.GetUsersInRoleAsync(Roles.Customer);

            var customers = _mapper.Map<IEnumerable<CustomerResponse>>(customersIdentity);

            return customers;
        }
    }
}