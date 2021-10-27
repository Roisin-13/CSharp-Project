using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.IO;
using Sales.Utils;
using System.Data;

using System.Globalization;

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


            using MySqlCommand command = connection.CreateCommand();

            connection.Open();
            command.CommandText = "select * from sales where year(date_of_sale)=@y1 order by date_of_sale";
            command.Parameters.AddWithValue("@y1", y1);
            MySqlDataReader reader = command.ExecuteReader();
            IList<SaleModel> sales = new List<SaleModel>();

            Console.WriteLine("Sales for " + y1 + " year");
            while (reader.Read()) { 
                int id = reader.GetFieldValue<int>("id");
                string name = reader.GetFieldValue<string>("name");
                int quantity = reader.GetFieldValue<int>("quantity");
                double price = reader.GetFieldValue<double>("price");
                DateTime date = reader.GetFieldValue<DateTime>("date_of_sale");

                    SaleModel sale = new SaleModel()
                    { ID = id, Name = name, Quantity = quantity, Price = price, Date = date };
                    sales.Add(sale);
            }
            if (!reader.HasRows)
            {
                connection.Close();
                return null;
                
            }
           
            connection.Close();
            return sales;

        }
      
        //-----read by year and month------//
        internal IEnumerable<SaleModel> ReadByYearMonth(int y2, int m2)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from sales where year(date_of_sale)=@y2 AND month(date_of_sale)=@m2 order by date_of_sale";
            command.Parameters.AddWithValue("@y2", y2);
            command.Parameters.AddWithValue("@m2", m2);
            MySqlDataReader reader = command.ExecuteReader();
            
            IList<SaleModel> sales = new List<SaleModel>();
            DateTimeFormatInfo monthName = new DateTimeFormatInfo();
            string getm2 = monthName.GetMonthName(m2);
  
            Console.WriteLine("Sales for " + getm2 + "  " + y2 + " :");

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
            if (!reader.HasRows)
            {
                connection.Close();
                return null;
            }

            connection.Close();
            return sales;


        }
        
        //==============ALL THE TOTAL METHODS===============//
        //-----total by year------//
     
        internal double? TotalByYear(int y3)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "select sum(price * quantity) from sales where year(date_of_sale)=@y3";
  
            command.Parameters.AddWithValue("@y3", y3);
 
            command.Prepare();

            var result = command.ExecuteScalar();
            connection.Close();
            try {
                Console.WriteLine("Total for year " + y3 + " is: £ " + result);
                return (double)result;
                
            } catch 
            {
                Console.WriteLine("No sales for " + y3 + " year");
                return null;

            }


        }

        //-----total by year and month------//
        internal double? TotalByYearMonth(int y4, int m4)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "select sum(price * quantity) from sales where year(date_of_sale)=@y4 AND month(date_of_sale)=@m4";

            command.Parameters.AddWithValue("@y4", y4);
            command.Parameters.AddWithValue("@m4", m4);

            command.Prepare();
            var result = command.ExecuteScalar();


            connection.Close();
            try
            {
                DateTimeFormatInfo monthName = new DateTimeFormatInfo();
                string getMonthName = monthName.GetMonthName(m4);
                Console.WriteLine("Total for " + getMonthName + " " + y4 + " is: £ " + result);
                return (double)result;
                
            }
            catch
            {
                DateTimeFormatInfo monthName = new DateTimeFormatInfo();
                string getMonthName = monthName.GetMonthName(m4);
                Console.WriteLine("No sales for " + getMonthName + " " + y4);
                return null;
            }
            

        }

        //==============ALL THE EXTRA METHODS===============//  
        //-----list between years------//
        internal IEnumerable<SaleModel> ListBetweenYears(int ys1, int ye1)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from sales where year(date_of_sale) between @ys1 and @ye1 order by date_of_sale";
            command.Parameters.AddWithValue("@ys1", ys1);
            command.Parameters.AddWithValue("@ye1", ye1);
            MySqlDataReader reader = command.ExecuteReader();
            
            IList<SaleModel> sales = new List<SaleModel>();
            Console.WriteLine("Sales between " + ys1 + " and " + ye1 + " :");
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

            if (!reader.HasRows)
            {
                connection.Close();
                return null;
            }
            connection.Close();
            return sales;
            

        }

        //-----list all sales between specified months and years------//
        internal IEnumerable<SaleModel> ListBetweenYearsMonth(int ys2, int ye2, int ms2, int me2)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from sales where date_of_sale between @start and last_day(@end) order by date_of_sale";
            command.Parameters.AddWithValue("@start", $"{ys2}-{ms2}-01");
            command.Parameters.AddWithValue("@end", $"{ye2}-{me2}-01");
         
            MySqlDataReader reader = command.ExecuteReader();

            IList<SaleModel> sales = new List<SaleModel>();
            DateTimeFormatInfo monthNameStart = new DateTimeFormatInfo();
            
            string getms2 = monthNameStart.GetMonthName(ms2);
            DateTimeFormatInfo monthNameEnd = new DateTimeFormatInfo();
            string getme2 = monthNameEnd.GetMonthName(me2);
            Console.WriteLine("Sales between " + getms2 + "  " + ys2 + " and " + getme2 + " " + ye2 + " :");

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

            if (!reader.HasRows)
            {
                connection.Close();
                return null;
            }
            connection.Close();
            return sales;


        }

        //-----average sales for a month between specified year range------//

        internal double? MonthAverage(int ys3, int ye3, int m3)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "select sum(price * quantity) from sales where year(date_of_sale) between @ys3 and @ye3 and month(date_of_sale)=@m3";

            command.Parameters.AddWithValue("@ys3", ys3);
            command.Parameters.AddWithValue("@ye3", ye3);
            command.Parameters.AddWithValue("@m3", m3);
            command.Prepare();
            var result = command.ExecuteScalar();


            connection.Close();
            try
            {
                var yearDiff = (double)ye3 - (double)ys3;
                double amount = (double)result;
                var averageResult = amount/yearDiff;
                var avRes = Math.Round(averageResult, 2, MidpointRounding.AwayFromZero);
                DateTimeFormatInfo monthName = new DateTimeFormatInfo();
                string getMonthName = monthName.GetMonthName(m3);
                Console.WriteLine("Average for month " + getMonthName + " between " + ys3  + " and "+  ye3 + " is: £ " + avRes);
                return (double)result;

            }
            catch
            {
                DateTimeFormatInfo monthName = new DateTimeFormatInfo();
                string getMonthName = monthName.GetMonthName(m3);
                Console.WriteLine("No sales for month " + getMonthName + " between " + ys3 + " and " + ye3);
                return null;
            }


        }
        //-----average sales for by month for a year------//
        internal double? YearByMonthAverage(int y4)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "select sum(price * quantity) from sales where year(date_of_sale)=@y4";

            command.Parameters.AddWithValue("@y4", y4);

            command.Prepare();

            var result = command.ExecuteScalar();
            connection.Close();
            try
            {
                double amount = (double)result;
                var averageResult = amount / 12;
                var avRes = Math.Round(averageResult, 2, MidpointRounding.AwayFromZero);
                Console.WriteLine("Average by month for year " + y4 + " is: £ " + avRes);
                return (double)result;

            }
            catch
            {
                Console.WriteLine("No sales for " + y4 + " year");
                return null;

            }


        }
        //-----month of a year that made the most sales ------//
        internal double? HighestMonthByYear(int y5)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "select extract(month from date_of_sale) as month, sum(price * quantity) as total from sales where year(date_of_sale)=@y5 group by month order by total desc;";

            command.Parameters.AddWithValue("@y5", y5);

            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();
            double total = 0;

            if(reader.Read())
            {
                total += Convert.ToDouble(reader["total"]);
                int month = 0;
                month += Convert.ToInt32(reader["month"]);
                DateTimeFormatInfo monthName = new DateTimeFormatInfo();
                string getMonthName = monthName.GetMonthName(month);
                Console.WriteLine("Month with the highest sales for year " + y5 + " is month " + getMonthName + " with: £ " + total);

            }
            if(!reader.HasRows)
            {
                connection.Close();
                Console.WriteLine("No sales for " + y5 + " year");

            }
            connection.Close();
            return (double)total;

        }
        //-----month of a year that made the least sales ------//
        internal double? LowestMonthByYear(int y6)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = "select extract(month from date_of_sale) as month, sum(price * quantity) as total from sales where year(date_of_sale)=@y6 group by month order by total asc";

            command.Parameters.AddWithValue("@y6", y6);

            command.Prepare();

            MySqlDataReader reader = command.ExecuteReader();
            double total = 0;

            if (reader.Read())
            {
                total += Convert.ToDouble(reader["total"]);
                int month = 0;
                month += Convert.ToInt32(reader["month"]);
                DateTimeFormatInfo monthName = new DateTimeFormatInfo();
                string getMonthName = monthName.GetMonthName(month);
                Console.WriteLine("Month with the lowest sales for year " + y6 + " is month " + getMonthName + " with: £ " + total);

            }
            if (!reader.HasRows)
            {
                connection.Close();
                Console.WriteLine("No sales for " + y6 + " year");

            }
            connection.Close();
            return (double)total;

        }










    }
}

