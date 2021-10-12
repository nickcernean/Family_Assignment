using System.Collections.Generic;
using Models;

namespace Family_Assignment.Data
{
    public interface IUserReader
    {
        IList<User> GetUsers();
        User ValidateUser(string userName, string password);
        bool IsUserRegistered(string userName, string password);
    }
}