using Microsoft.Data.SqlClient;
using System.Configuration;

namespace PersonelTakip
{
    public class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
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
            Application.Run(new LoginForm());
        }
    }
}