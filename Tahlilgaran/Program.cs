using Microsoft.EntityFrameworkCore;
using Tahlilgaran.Data;
using Tahlilgaran.Forms;

namespace Tahlilgaran
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using (var db = new AppDBContext())
            {
                db.Database.Migrate();
            }

            Application.Run(new LoginForm());
        }
    }
}