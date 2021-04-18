using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ViewModelShare.Category;
using ViewModelShare.Customer;

namespace backend.Repositories.CustomerRepo
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerResponse>> GetCustomers();
    }
}