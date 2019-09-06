using System.Collections.Generic;
using NetCoreExamples.Models.Dtos;
using NetCoreExamples.Models.InputModels;

namespace NetCoreExamples.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
         int CreateNewCustomer(CustomerInputModel customer);
         CustomerDto GetCustomerById(int id);
         IEnumerable<CustomerDto> GetAllCustomers();
    }
}