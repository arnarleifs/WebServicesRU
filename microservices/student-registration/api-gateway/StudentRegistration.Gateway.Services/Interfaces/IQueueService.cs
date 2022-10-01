namespace StudentRegistration.Gateway.Services.Interfaces
{
    public interface IQueueService
    {
        void PublishTopic<T>(string routingKey, T data) where T : class;
    }
}