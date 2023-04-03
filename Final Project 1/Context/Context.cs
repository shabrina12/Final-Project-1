using System.Data.SqlClient;

namespace Final_Project_1.Context;
public class MyContext
{
    private static SqlConnection connection;

    private static string connectionString = "Data Source=DESKTOP-I3RV54S;Initial Catalog=db_perpustakaan;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public static SqlConnection GetConnection()
    {
        try
        {
            connection = new SqlConnection(connectionString);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return connection;
    }
}
