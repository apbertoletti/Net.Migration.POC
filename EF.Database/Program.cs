using Microsoft.EntityFrameworkCore;
using System;

namespace EF.Database
{
    class Program
    {
        private static string connectionString_Sandbox = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=NomeBDPreExistente;Integrated Security=true";

        private static string connectionString_Production = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=NomeBDPreExistente_prod;Integrated Security=true";

        static int Main(string[] args)
        {
            Console.WriteLine("Do you want to run the migrations in the [S]andbox or [P]roduction target database?");
            var targetDatabase = Console.ReadLine();            

            AppContext context;
            switch (targetDatabase.ToUpper())
            {
                case "S":
                    context = new AppContext(connectionString_Sandbox);
                    break;

                case "P":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Are you sure to run in PRODUCTION database? [Y]es or [N]o");
                    Console.ResetColor();
                    var responseProduction = Console.ReadLine();
                    switch (responseProduction.ToUpper())
                    {
                        case "Y":
                            context = new AppContext(connectionString_Production);
                            break;

                        default:
                            Console.WriteLine("Migration aborted!");
                            return -1;
                    }
                    break;

                default:
                    Console.WriteLine("Invalid target database!");
                    Console.ReadKey();
                    return -1;
            }

            try
            {
                context.Database.Migrate();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Migration succeeded!");
                Console.ResetColor();

                return 0; //This value can be used to DevOps flow
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Migration error:");
                Console.WriteLine("=====================================");
                Console.WriteLine(e.Message);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
                return -1;
                throw;
            }
        }
    }
}
