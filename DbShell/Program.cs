using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using DBProvider.Models;

namespace DbShell
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DBProvider.MainDBContext();


            //db.Users.Add(new User() { Name = "Start" });
            //db.Users.Add(new User() { Name = "Start2" });
            //db.SaveChanges();
            db.Users.AsEnumerable().All((el) =>
            {
                Console.WriteLine(JsonSerializer.Serialize<User>(el));
                return true;
            });
         }
    }
}
