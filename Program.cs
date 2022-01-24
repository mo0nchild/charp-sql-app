using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace MyProgram;

public class Program
{

    public static void Main()
    {

        var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString);
        sqlConnection.Open();

        if (sqlConnection.State == ConnectionState.Open) 
        {
            Console.WriteLine("Connection STATUS: OK");
            SqlDataReader? sqlDataReader = null;

            try
            {
                SqlCommand sqlCommand = new SqlCommand("select * from Students", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) 
                {
                    Console.WriteLine($"{sqlDataReader["Name"]}\t\t\t{sqlDataReader["Age"]}\t\t\t{sqlDataReader["Birthday"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                sqlConnection.Close();
                sqlDataReader?.Close();
            }
        }

    }

}