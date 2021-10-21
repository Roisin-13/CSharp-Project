using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.IO;
using Sales.Utils;
using System.Data;

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
        //==============ALL THE READ METHODS===============//

        //-----read by year------//
        internal IEnumerable<SaleModel> ReadByYear(int y1)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from sales where year(date_of_sale)='{y1}'";
            MySqlDataReader reader = command.ExecuteReader();

            IList<SaleModel> sales = new List<SaleModel>();
            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>("id");
                string name = reader.GetFieldValue<string>("name");
                int quantity = reader.GetFieldValue<int>("quantity");
                double price = reader.GetFieldValue<double>("price");
                DateTime date = reader.GetFieldValue<DateTime>("date_of_sale");
                SaleModel sale = new SaleModel()
                { ID = id, Name = name, Quantity = quantity, Price = price, Date = date };
                sales.Add(sale);
            }

            connection.Close();
            return sales;
        }
        //-----read by year and month------//
        internal IEnumerable<SaleModel> ReadByYearMonth(int y2, int m2)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from sales where year(date_of_sale)='{y2}' AND month(date_of_sale)='{m2}'";
            MySqlDataReader reader = command.ExecuteReader();

            IList<SaleModel> sales2 = new List<SaleModel>();
            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>("id");
                string name = reader.GetFieldValue<string>("name");
                int quantity = reader.GetFieldValue<int>("quantity");
                double price = reader.GetFieldValue<double>("price");
                DateTime date = reader.GetFieldValue<DateTime>("date_of_sale");
                SaleModel sale = new SaleModel()
                { ID = id, Name = name, Quantity = quantity, Price = price, Date = date };
                sales2.Add(sale);
            }

            connection.Close();
            return sales2;
        }





    }
}
