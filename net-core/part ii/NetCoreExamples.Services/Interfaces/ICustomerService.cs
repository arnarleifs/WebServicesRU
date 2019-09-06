using System.Collections.Generic;
using NetCoreExamples.Models.Dtos;
using NetCoreExamples.Models.InputModels;

namespace NetCoreExamples.Services.Interfaces
{
    public interface ICustomerService
    {
         int CreateNewCustomer(CustomerInputModel customer);
         IEnumerable<CustomerDto> GetAllCustomers();
         CustomerDto GetCustomerById(int id);
    }
}