namespace LoadTestDemo.Models
{
    public interface IUserRepository
    {
        bool ValidateUser(string userName, string password);
    }
}