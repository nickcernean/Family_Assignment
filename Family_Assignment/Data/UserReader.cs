using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Family_Assignment.Data
{
    public class UserReader : IUserReader
    {
        private FileContext FileContext;
        
        public UserReader()
        {
            FileContext = new FileContext();
        }

        public IList<User> GetUsers()
        {
            return FileContext.Users;
        }

        public User ValidateUser(string userName, string password)
        {
            User checkUser = GetUsers().FirstOrDefault(user => user.UserName.Equals(userName));

            if (checkUser == null)
            {
                throw new Exception("User not found");
            }

            if (!checkUser.Password.Equals(password))
            {
                throw new Exception("Wrong password");
            }

            return checkUser;
        }

        public bool IsUserRegistered(string userName, string password)
        {
            User checkUser = GetUsers().FirstOrDefault(user => user.UserName.Equals(userName));

            if (checkUser != null)
            {
                throw new Exception("User already exist !");
            }

            User user = new User();
            user.UserName = userName;
            user.Password = password;
            
            GetUsers().Add(user);
            return false;
        }
    }
}