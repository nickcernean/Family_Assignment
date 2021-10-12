using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Family_Assignment.Data
{
    public class UserReader : IUserReader
    {
        private FileContext FileContext;
        private IList<User> users;

        public UserReader()
        {
            FileContext = new FileContext();
            users = FileContext.Users;
        }
        

        public User ValidateUser(string userName, string password)
        {
            User checkUser = users.FirstOrDefault(user => user.UserName.Equals(userName));

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

        public User RegisterUser(string userName, string password)
        {
            User checkUser = users.FirstOrDefault(user => user.UserName.Equals(userName));

            if (checkUser != null)
            {
                throw new Exception("User already exist !");
            }

            User user = new User();
            user.UserName = userName;
            user.Password = password;
            users.Add(user);
            FileContext.SaveChanges();
            return user;
        }
    }
}