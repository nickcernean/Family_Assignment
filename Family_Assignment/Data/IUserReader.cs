using System.Collections.Generic;
using Models;

namespace Family_Assignment.Data
{
    public interface IUserReader
    {
        User ValidateUser(string userName, string password);
        User RegisterUser(string userName, string password);
    }
}