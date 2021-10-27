using Sales.Sales;
using System;
using MySql.Data.MySqlClient;

using System.IO;
using Sales.Utils;
//using Sales.Exceptions;

namespace Sales
{
    class Program
    {
        static void Main(string[] args)
        {
           
            MySqlConnection connection = mySqlUtils.GetConnection();
            Menu menu = new Menu(new Controller(
                    new Services(
                        new Repository(connection))));
            menu.firstMenu();


        }
   
       

    }
}
