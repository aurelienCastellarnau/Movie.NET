using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Model1Container ctx = new Model1Container();

            User user = new User();
            user.Login = "John";
            user.Password = "pass";

            ctx.Users.Add(user);

            ctx.SaveChanges();
        }
    }
}
