using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NetCoreExamples.Models.Entities;
using NetCoreExamples.Repositories.Implementations;
using NetCoreExamples.Repositories.Interfaces;
using AutoMapper;
using Bogus;

namespace NetCoreExamples.Tests.RepositoryTests
{
    [TestClass]
    public class CustomerRepositoryTests
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerRepositoryTests()
        {
            var customerFaker = new Faker<Customer>()
              .RuleFor(c => c.Id, f => f.IndexFaker)
             .RuleFor(c => c.Name, f => f.Person.FullName)
             .RuleFor(c => c.Email, f => f.Person.Email)
             .RuleFor(c => c.Bio, f => f.Lorem.Sentence());

            var mapperConfig = new MapperConfiguration(expression => {});
            var mapper = mapperConfig.CreateMapper();

            var customers = customerFaker.Generate(20);
            var dataProviderMock = new Mock<IDataProvider>();

            dataProviderMock.Setup(c => c.GetCustomers()).Returns(customers);
            _customerRepository = new CustomerRepository(dataProviderMock.Object, mapper);
        }

        [TestMethod]
        public void GetAllCustomers_ShouldReturnAListOfLength20()
        {
            var customers = _customerRepository.GetAllCustomers();
            Assert.AreEqual(20, customers.Count());
        }
    }
}