using ModelMovieNet.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMovieNet.Dao
{
    class UserDao : IUserDao
    {

        public User CreateUser(User user)
        {
            DataModelContainer ctx = new DataModelContainer();
            Console.WriteLine("user in create: " + user.Login);
            ctx.UserSet.Add(user);
            ctx.SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            DataModelContainer ctx = new DataModelContainer();
            User updated = ctx.UserSet.Where(u => u.Id == user.Id).FirstOrDefault();
            if (updated.Equals(user))
            {
                ctx.SaveChanges();
                return updated;
            }
            else
            {
                throw new Exception("Update failed");
            }
        }

        public bool DeleteUser(User user)
        {
            DataModelContainer ctx = new DataModelContainer();
            ctx.UserSet.Remove(user);
            ctx.SaveChanges();
            return true;
        }

        public List<User> getAllUsers()
        {
            DataModelContainer ctx = new DataModelContainer();
            return ctx.UserSet.ToList();
        }

        public User GetUser(int uid)
        {
            DataModelContainer ctx = new DataModelContainer();
            return ctx.UserSet.Where(u => u.Id == uid).FirstOrDefault();
        }

        public User LogUser(User user)
        {
            DataModelContainer ctx = new DataModelContainer();
            return ctx.UserSet
                .Where(u => u.Login == user.Login && user.Password == u.Password)
                .Select(u => u).FirstOrDefault();
        }
    }
}
