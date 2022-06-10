using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Connected
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            string connectionString = GetConnectionString();
            string query1 = "Select * from Pembimbing_Akademik where NIK=333";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd1 = new SqlCommand(query1, cn); cn.Open();
                using (SqlDataReader dr1 = cmd1.ExecuteReader())
                {
                    while (dr1.Read())
                    {
                        string query2 = "UPDATE Pembimbing_Akademik SET Keahlian = 'Jaringan' WHERE NIK = 333";
                        SqlCommand cmd2 = new SqlCommand(query2, cn);
                        cmd2.ExecuteNonQuery();
                        Console.WriteLine("Data has been updated");
                    }
                }
            }
            Console.ReadLine();
        }
        private static string GetConnectionString()
        {
            return "data source = LAPTOP-4BKVT6FE;database=ProdiTI;MultipleActiveResultSets=True;User ID=sa;Password=Galantis00";
        }
    }
}
