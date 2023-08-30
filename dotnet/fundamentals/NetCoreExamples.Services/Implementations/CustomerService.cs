using System.Collections.Generic;
using NetCoreExamples.Models.Dtos;
using NetCoreExamples.Models.InputModels;
using NetCoreExamples.Repositories;
using NetCoreExamples.Repositories.Implementations;
using NetCoreExamples.Repositories.Interfaces;
using NetCoreExamples.Services.Interfaces;

namespace NetCoreExamples.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public int CreateNewCustomer(CustomerInputModel customer) => _customerRepository.CreateNewCustomer(customer);
        public IEnumerable<CustomerDto> GetAllCustomers() => _customerRepository.GetAllCustomers();
        public CustomerDto GetCustomerById(int id) => _customerRepository.GetCustomerById(id);
    }
}