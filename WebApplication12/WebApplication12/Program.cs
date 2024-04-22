using System;
using Microsoft.EntityFrameworkCore;
using WebApplication12.Data;

namespace WebApplication12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new UserContext())
            {
                context.Database.EnsureCreated();
                context.Users.RemoveRange(context.Users);

                var user1 = new User { FirstName = "Nadiika", LastName = "Shevchuk", Age = 20 };
                var user2 = new User { FirstName = "Volodymyr", LastName = "Lialiuk", Age = 21 };
                var user3 = new User { FirstName = "Valerii", LastName = "Bardakov", Age = 21 };

                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);

                context.SaveChanges();

                var users = context.Users.ToList();
                Console.WriteLine("List of users:");
                foreach (var user in users)
                {
                    Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}, Age: {user.Age}");
                }
               // /*
                var userToUpdate = context.Users.FirstOrDefault(u => u.FirstName == "Nadiika");
                if (userToUpdate != null)
                {
                    userToUpdate.Age = 25; 
                    context.SaveChanges(); 
                    Console.WriteLine("User data updated");
                }

                var userToDelete = context.Users.FirstOrDefault(u => u.LastName == "Bardakov");
                if (userToDelete != null)
                {
                    context.Users.Remove(userToDelete);
                    context.SaveChanges(); 
                    Console.WriteLine("User deleted");
                }

                var updatedUsers = context.Users.ToList();
                Console.WriteLine("Updated list of users:");
                foreach (var user in updatedUsers)
                {
                    Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}, Age: {user.Age}");
                }
              //  */
            }
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<CompanyContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
