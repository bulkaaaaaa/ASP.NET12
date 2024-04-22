using WebApplication12.Models;

namespace WebApplication12.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CompanyContext context)
        {
            context.Database.EnsureCreated();

            if (context.Companies.Any())
            {
                return;
            }

            context.Companies.AddRange(
                new Company { Name = "EPAM Systems", Location = "Kyiv", EmployeeCount = 41000 },
                new Company { Name = "GlobalLogic", Location = "Lviv", EmployeeCount = 20000 },
                new Company { Name = "SoftServe", Location = "Lviv", EmployeeCount = 12000 },
                new Company { Name = "Luxoft", Location = "Kyiv", EmployeeCount = 13000 },
                new Company { Name = "Grammarly", Location = "Kyiv", EmployeeCount = 500 }
            );

            context.SaveChanges();
        }

    }
}
