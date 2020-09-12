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

namespace NetCoreExamples.Tests.RepositoryTests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private ICustomerRepository _customerRepository;
        private readonly Mock<IDataProvider> _dataProviderMock = new Mock<IDataProvider>();
        private List<Customer> _customers = Builder<Customer>.CreateListOfSize(3).Build().ToList();

        [TestInitialize]
        public void Initialize()
        {
            _dataProviderMock.Setup(d => d.GetCustomers()).Returns(_customers);
            _customerRepository = new CustomerRepository(_dataProviderMock.Object);
        }

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAListOfLengthFive()
        {
            var customers = _customerRepository.GetAllCustomers();
            Assert.AreEqual(3, customers.Count());
        }
    }
}