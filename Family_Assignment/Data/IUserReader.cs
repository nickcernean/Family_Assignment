using Models;

namespace Family_Assignment.Data
{
    public interface IUserReader
    {
        User ValidateUser(string userName, string password);
        bool IsUserRegistered(string userName,string password);
    }
}