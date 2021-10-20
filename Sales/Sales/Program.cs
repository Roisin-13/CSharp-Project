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
            //============DB connection===================//
            //---don't think I need this bad boy anymore - bye
            MySqlConnection connection = mySqlUtils.GetConnection();
            connection.Open();
            //----connecting to sql file
            mySqlUtils.RunSchema(Environment.CurrentDirectory + @"\static\schema.sql", connection);
            //---checking connection
            bool connectionOpen = connection.Ping();
            Console.WriteLine($@"Connection status: {connection.State}
            Ping successful: {connectionOpen}
            DB version: {connection.ServerVersion}");

            connection.Dispose();
            //firstMenu();

        }
        //public static void firstMenu()
        //{
        //    Menu menu = new Menu(new Controller(
        //        new Services(
        //            new Repository())));
            
        //    menu.firstMenu();
        //}

    }
}
