using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.IO;

namespace Sales.Utils
{
    class mySqlUtils
    {
        //-----for connection to MySQL database:
        //---copied direct from QA see below for website:
        //(https://qa-community.co.uk/~/_/learning/c-sharp-intermediate/c-sharp--mysql)
        public static MySqlConnectionStringBuilder ConnectionString { get; set; } = new MySqlConnectionStringBuilder
        {
            Server = "127.0.0.1",
            UserID = "root",
            Password = "root",
            Port = 3306,
            Database = "sales",
            AllowBatch = true,
            AllowLoadLocalInfileInPath = "./",
            AllowLoadLocalInfile = false,
            ConnectionTimeout = 30
        };

        //--connection object, takes string builder to open connection to database
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString.ConnectionString);
        }

        //-----method for running a schema (with database connection to run schema against)
        public static void RunSchema(string path, MySqlConnection connection)
        {
            string schema = File.ReadAllText(path);
            MySqlCommand mySqlCommand = connection.CreateCommand();
            mySqlCommand.CommandText = schema;

            mySqlCommand.ExecuteNonQuery();
        }


    }
}
