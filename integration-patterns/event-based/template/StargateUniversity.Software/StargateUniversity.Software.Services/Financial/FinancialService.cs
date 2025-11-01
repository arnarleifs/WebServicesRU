using StargateUniversity.Software.Contracts.Dtos.Financial;
using StargateUniversity.Software.Contracts.Entities;
using StargateUniversity.Software.Services.DAL;

namespace StargateUniversity.Software.Services.Financial;

public class FinancialService : IFinancialService
{
    private readonly FinancialDbContext _financialDbContext;

    public FinancialService(FinancialDbContext financialDbContext)
    {
        _financialDbContext = financialDbContext;
    }

    public async Task StoreFinancialRecord(FinancialRecordCreationInputModel inputModel)
    {
        var entity = new FinancialRecord
        {
            FullName = inputModel.FullName,
            EmailAddress = inputModel.EmailAddress,
            Address = inputModel.Address,
            PostalCode = inputModel.PostalCode,
            City = inputModel.City,
            Salary = inputModel.Salary,
            Currency = inputModel.Currency,
            Department = inputModel.Department
        };

        await _financialDbContext.AddAsync(entity);
        await _financialDbContext.SaveChangesAsync();
    }
}