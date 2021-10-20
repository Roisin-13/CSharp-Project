using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.IO;
using Sales.Utils;

namespace Sales.Sales
{
    class Repository
    {

        private readonly MySqlConnection connection;
        //public MySqlConnection connection { get; }
        public Repository(MySqlConnection mySqlConnection)
        {
            this.connection = mySqlConnection;
        }

        //===========DATA ENTRY============//
        internal SaleModel Create(SaleModel toCreate)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into sales(name, quantity, price, date_of_sale) " +
                "values(@Name, @Quantity, @Price, @Date)";
            command.Parameters.AddWithValue("@Name", toCreate.Name);
            command.Parameters.AddWithValue("@Quantity", toCreate.Quantity);
            command.Parameters.AddWithValue("@Price", toCreate.Price);
            command.Parameters.AddWithValue("@Date", toCreate.Date);
            command.Prepare();
            command.ExecuteNonQuery();

            connection.Close();

            SaleModel sale = new SaleModel();
            sale.ID = (int)command.LastInsertedId;
            sale.Name = toCreate.Name;
            sale.Quantity = toCreate.Quantity;
            sale.Price = toCreate.Price;
            sale.Date = toCreate.Date;
            return sale;



        }




    }
}
