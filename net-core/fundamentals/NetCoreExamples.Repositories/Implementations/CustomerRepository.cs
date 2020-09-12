using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using NetCoreExamples.Models.Dtos;
using NetCoreExamples.Models.Entities;
using NetCoreExamples.Models.InputModels;
using NetCoreExamples.Repositories.Interfaces;

namespace NetCoreExamples.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDataProvider _dataProvider;

        public CustomerRepository(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public int CreateNewCustomer(CustomerInputModel customer)
        {
            var customers = _dataProvider.GetCustomers();
            var entity = Mapper.Map<Customer>(customer);
            entity.Id = customers.Count + 1;
            customers.Add(entity);

            return entity.Id;
        }

        public CustomerDto GetCustomerById(int id) => Mapper.Map<CustomerDto>(_dataProvider.GetCustomers().FirstOrDefault(c => c.Id == id));

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            return _dataProvider.GetCustomers().Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Ssn = c.Ssn,
                Email = c.Email,
                StreetAddress = c.StreetAddress,
                City = c.City,
                Country = c.Country,
                Bio = c.Bio
            });
        }
    }
}