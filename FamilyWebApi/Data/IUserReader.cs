using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Family_Assignment.Data
{
    public interface IUserReader
    {
       Task<User> ValidateUserAsync(string userName);
        Task<User> RegisterUserAsync(User user);
    }
}