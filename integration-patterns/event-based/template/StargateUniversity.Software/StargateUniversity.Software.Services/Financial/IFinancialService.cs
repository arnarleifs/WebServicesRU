using StargateUniversity.Software.Contracts.Dtos.Financial;

namespace StargateUniversity.Software.Services.Financial;

public interface IFinancialService
{
    Task StoreFinancialRecord(FinancialRecordCreationInputModel inputModel);
}