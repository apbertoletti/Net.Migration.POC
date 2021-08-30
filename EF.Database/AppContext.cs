using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Database
{
    public class AppContext : DbContext
    {
        //The connection string can be read from the some external file
        const string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=NomeBDPreExistente;Integrated Security=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}
