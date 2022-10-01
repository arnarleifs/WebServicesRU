using Microsoft.Extensions.DependencyInjection;

namespace StudentRegistration.UserService.Console.Handlers
{
    public static class HandlerFactory
    {
        public static IHandler? GetHandlerByRoutingKey(string routingKey, IServiceProvider provider) =>
            routingKey switch {
                "student-registration-request" => provider.GetRequiredService<StudentRegisterHandler>(),
                _ => null
            };
    }
}