using Sales.Sales;
using System;
using MySql.Data.MySqlClient;

using System.IO;
using Sales.Utils;


namespace Sales
{
    class Program
    {
        static void Main(string[] args)
        {

            MySqlConnection connection = mySqlUtils.GetConnection();
            try
            {

                Menu menu = new Menu(new Controller(
                        new Services(
                            new Repository(connection))));
                menu.firstMenu();

            }
            catch (MySqlException)
            {
                Console.WriteLine("Cannot connect to the server");
            }
            finally
            {
                if (connection != null)
                {
                    connection.Dispose();
                }
            }


        }
   
       

    }
}
