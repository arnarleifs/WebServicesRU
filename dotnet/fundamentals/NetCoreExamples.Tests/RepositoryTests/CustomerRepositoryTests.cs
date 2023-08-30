using System;
using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NetCoreExamples.Models.Entities;
using NetCoreExamples.Repositories.Implementations;
using NetCoreExamples.Repositories.Interfaces;
using NetCoreExamples.Tests.Mocks;
using AutoMapper;

namespace NetCoreExamples.Tests.RepositoryTests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private ICustomerRepository _customerRepository;
        private readonly Mock<IDataProvider> _dataProviderMock = new Mock<IDataProvider>();
        IMapper _mapper;
        MapperConfiguration _config;
        private List<Customer> _customers = Builder<Customer>.CreateListOfSize(3).Build().ToList();

        [TestInitialize]
        public void Initialize()
        {
            _config = new MapperConfiguration(cfg => cfg.AddMaps(new[] {
                "NetCoreExamples.WebApi"
            }));

            _mapper = _config.CreateMapper();
            _dataProviderMock.Setup(d => d.GetCustomers()).Returns(_customers);
            _customerRepository = new CustomerRepository(_dataProviderMock.Object, _mapper);
        }

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAListOfLengthFive()
        {
            var customers = _customerRepository.GetAllCustomers();
            Assert.AreEqual(3, customers.Count());
        }
    }
}