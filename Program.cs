using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using MySql.Data.MySqlClient;

namespace MyProgram;


class MySqlServer
{

    string connectionString { get; } = ConfigurationManager.ConnectionStrings["MysqlDataBase"].ConnectionString;
    public MySqlConnection connection { private set; get; }


    private MySqlServer()
    {
        connection = new MySqlConnection(connectionString);
        connection.Open(); 
    }

    private void GetData() 
    {
        MySqlDataReader? sqlDataReader = null;
        try
        {
            MySqlCommand sqlCommand = new MySqlCommand("select * from users", this.connection);
            sqlDataReader = sqlCommand.ExecuteReader();

            Console.WriteLine($"\n\t[ NAME ]\t\t[ AGE ]\n");
            while (sqlDataReader.Read())
            {
                Console.WriteLine($"\t{sqlDataReader["Name"]}\t\t\t{sqlDataReader["Age"]}");
            }
        }
        finally
        {
            sqlDataReader?.Close();
        }
    }

    public static void Run() 
    {
        MySqlServer? server = null;
        try
        {
            server = new MySqlServer();
            Console.WriteLine("Connection OK");
            server.GetData();


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally 
        {
            server?.connection.Close();
        }
   
    }

}

class MsSqlServer 
{

    string connectionString { get; } = ConfigurationManager.ConnectionStrings["MssqlDataBase"].ConnectionString;
    public SqlConnection connection { private set; get; }


    private MsSqlServer()
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    private void GetData()
    {
        SqlDataReader? sqlDataReader = null;
        try
        {
            SqlCommand sqlCommand = new SqlCommand("select * from users", this.connection);
            sqlDataReader = sqlCommand.ExecuteReader();

            Console.WriteLine($"\n\t[ NAME ]\t\t[ AGE ]\t\t\t[ BIRTHDAY ]\n");
            while (sqlDataReader.Read())
            {
                Console.WriteLine($"\t{sqlDataReader["Name"]}\t\t\t{sqlDataReader["Age"]}\t\t\t{sqlDataReader["Birthday"]}");
            }
        }
        finally
        {
            sqlDataReader?.Close();
        }
        

    }

    public static void Run()
    {
        MsSqlServer? server = null;
        try
        {
            server = new MsSqlServer();
            Console.WriteLine("Connection OK");
            server.GetData();


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            server?.connection.Close();
        }

    }

}


public class Program
{

    public static void Main()
    {
        MySqlServer.Run();
    }

}