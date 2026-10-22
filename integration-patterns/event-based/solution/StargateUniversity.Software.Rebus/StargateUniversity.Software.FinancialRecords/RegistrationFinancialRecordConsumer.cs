using Rebus.Handlers;
using StargateUniversity.Software.Contracts.Events;

namespace StargateUniversity.Software.FinancialRecords;

public class RegistrationFinancialRecordConsumer(ILogger<RegistrationFinancialRecordConsumer> logger)
    : IHandleMessages<EmployeeRegistrationEvent>
{
    public Task Handle(EmployeeRegistrationEvent message)
    {
        logger.LogInformation("Handling financial record for employee registration");

        // TODO: Store employee data in financial database
        return Task.CompletedTask;
    }
}
