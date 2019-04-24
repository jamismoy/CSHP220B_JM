using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });


            // Problem # 1
            var helloUsers = users.Where(user => user.Password == "hello");
            foreach (var x in helloUsers)
            {
                Console.WriteLine($"{x.Name} password is {x.Password}");
            }

            // Problem # 2
            users.RemoveAll(user => user.Password == user.Name.ToLower());

            // Problem # 3
            // Remove() Only removes the first Occurance
            users.Remove(helloUsers.First());

            // Problem # 4
            Console.Write("Remaining Users is: ");
            foreach (var x in users)
            {
                Console.WriteLine($"{x.Name} password is {x.Password}");
            }
            Console.ReadLine();
        }
    }
}
