using System;
using System.Linq;

namespace SchoolEF
{
    class Program
    {
        static void Main()
        {
            // Database accessor. This opens the database automatically
            var school = new SchoolEntities();

            var results = school.RetrieveClassesForStudent(1);

            foreach (var result in results)
            {
                var userName = school.Users.First(t => t.UserId == result.UserId).UserName;
                var className = school.ClassMasters.First(t => t.ClassId == result.Classid).ClassName;

                Console.WriteLine("User: {0}-{1} Class: {2}-{3}", result.UserId, userName, result.Classid, className);
            }

            Console.WriteLine("Classes ======================");
            // This accesses the ClassMaster table
            foreach (var classMaster in school.ClassMasters)
            {
                Console.WriteLine("ClassId: {0}\nClassName: {1}\nClassDescription: {2}\nClassPrice: {3}\n",
                    classMaster.ClassId, classMaster.ClassName, classMaster.ClassDescription, classMaster.ClassPrice);
            }

            Console.WriteLine("Users ======================");
            foreach (var user in school.Users)
            {
                Console.WriteLine(user.UserName);
                foreach (var classMaster in user.ClassMasters)
                {
                    Console.WriteLine("ClassId: {0} ClassName: {1}",
                        classMaster.ClassId, classMaster.ClassName);
                }
            }

            Console.Write("Done.");
            Console.ReadLine();
        }
    }
}
