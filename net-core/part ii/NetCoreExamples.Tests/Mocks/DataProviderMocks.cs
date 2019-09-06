using System;
using System.Collections.Generic;
using NetCoreExamples.Models.Entities;
using NetCoreExamples.Repositories.Interfaces;

namespace NetCoreExamples.Tests.Mocks
{
    public class DataProviderMocks : IDataProvider
    {
        public List<Customer> GetCustomers()
        {
            return new List<Customer> 
                {
                    new Customer 
                    {
                        Id = 1,
                        Name = "Customer 1",
                        Ssn = "1111111101",
                        Email = "customer1@example.com",
                        StreetAddress = "Customer Street 1",
                        City = "Reykjavik",
                        Country = "Iceland",
                        Bio = "Short bio on customer 1",
                        ModifiedBy = "CustomerAdmin",
                        ModifiedDate = DateTime.Now,
                        CreatedDate = DateTime.Now
                    },
                    new Customer
                    {
                        Id = 2,
                        Name = "Customer 2",
                        Ssn = "1111111102",
                        Email = "customer2@example.com",
                        StreetAddress = "Customer Street 2",
                        City = "Reykjavik",
                        Country = "Iceland",
                        Bio = "Short bio on customer 2",
                        ModifiedBy = "CustomerAdmin",
                        ModifiedDate = DateTime.Now,
                        CreatedDate = DateTime.Now
                    },
                    new Customer
                    {
                        Id = 3,
                        Name = "Customer 3",
                        Ssn = "1111111103",
                        Email = "customer3@example.com",
                        StreetAddress = "Customer Street 3",
                        City = "Reykjavik",
                        Country = "Iceland",
                        Bio = "Short bio on customer 3",
                        ModifiedBy = "CustomerAdmin",
                        ModifiedDate = DateTime.Now,
                        CreatedDate = DateTime.Now
                    }
                };
        }
    }
}