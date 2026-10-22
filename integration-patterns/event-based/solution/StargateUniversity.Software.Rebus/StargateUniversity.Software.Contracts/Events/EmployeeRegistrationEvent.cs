namespace StargateUniversity.Software.Contracts.Events;

public class EmployeeRegistrationEvent
{
    public string FullName { get; set; } = null!;
    public string EmailAddress { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public decimal Salary { get; set; }
    public string Currency { get; set; } = null!;
    public string Department { get; set; } = null!;
}