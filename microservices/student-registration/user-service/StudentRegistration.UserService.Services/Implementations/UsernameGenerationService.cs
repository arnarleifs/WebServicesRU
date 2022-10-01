using StudentRegistration.UserService.Data.Contexts;
using StudentRegistration.UserService.Data.Entities;

namespace StudentRegistration.UserService.Services.Implementations
{
    public class UsernameGenerationService
    {
        public static string GenerateUsername(string fullName, string semester)
        {
            var firstName = fullName.Split(" ").FirstOrDefault();
            var semesterEndYear = semester.Split("/").LastOrDefault();
            return $"{firstName}{semesterEndYear}".ToLower();
        }
    }
}