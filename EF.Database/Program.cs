using Microsoft.EntityFrameworkCore;
using System;

namespace EF.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            var context = new AppContext();

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
