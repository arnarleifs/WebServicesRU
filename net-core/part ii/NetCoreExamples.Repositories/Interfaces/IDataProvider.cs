using System.Collections.Generic;
using NetCoreExamples.Models.Entities;

namespace NetCoreExamples.Repositories.Interfaces
{
    public interface IDataProvider
    {
         List<Customer> GetCustomers();
    }
}