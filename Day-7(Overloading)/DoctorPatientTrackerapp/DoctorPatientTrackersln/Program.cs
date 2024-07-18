using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Server=52.143.121.117,1401;Database=ProductManager;User Id=senthamil;Password=Senthamil@2003;";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Successfully connected to the database.");

                string sql = "SELECT * FROM Products"; // Adjust table name if different
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ProductId: {reader["ProductName"]}");
                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine($"SQL Error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}