using System.Collections.Generic;
using System.Linq;

namespace LoadTestDemo.Models
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users;

        static UserRepository()
        {
            _users = new List<User>();
            for (var i = 0; i < 1000; i++)
                _users.Add(new User { Name = "user" + i, Password = "password" });
        }

        public bool ValidateUser(string userName, string password)
        {
            return _users.Any(user => user.Name.Equals(userName) && user.Password.Equals(password));
        }
    }
}