using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

using System.IO;
using Sales.Utils;
using Sales.Exceptions;

namespace Sales.Sales
{
    class Controller
    {
        //------linking services with controller
        private readonly Services services;
        public Controller(Services services)
        {
            this.services = services;
        }
        //==============DATA ENTRY METHOD===============//
        public void Create()
        {
            Console.WriteLine("Please enter Product name:");
            var name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You Must input product name");
                name = Console.ReadLine();
            }
            Console.WriteLine("Please enter quantity of product:");
            var quantityInput = Console.ReadLine();
            while (string.IsNullOrEmpty(quantityInput))
            {
                Console.WriteLine("You must enter a quantity of product:");
                quantityInput = Console.ReadLine();
                
            }
            var quantity = int.Parse(quantityInput);
            Console.WriteLine("Please enter price of product (in pounds and pence):");
            var priceInput = Console.ReadLine();
            while (string.IsNullOrEmpty(priceInput))
            {
                Console.WriteLine("You must enter a price for product:");
                priceInput = Console.ReadLine();
            }
            var price = double.Parse(priceInput);
            Console.WriteLine("Please enter date product was purchased (DD/MM/YYYY):");
            Console.WriteLine("If input incorrectly, or blank - will default to todays date");
            string dateInput = Console.ReadLine();
            var a = DateTime.TryParse(dateInput, out DateTime date);
            if (!a)
            {
                date = DateTime.Now;
            }
            else
            {
                date = DateTime.ParseExact(dateInput, "d", null);
            }

            SaleModel toCreate = new SaleModel(name, quantity, price, date);
            SaleModel newSale = services.Create(toCreate);
            Console.WriteLine($"Created new sale {newSale}");

        }

        //==============ALL THE READ METHODS===============//



        //-----read by year------//
        public void ReadByYear()
        {

            Console.WriteLine("Please enter Year of items you want to list (YYYY):");
            string inputYear = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYear))
            {
                Console.WriteLine("You must enter a year value");
                inputYear = Console.ReadLine();
            }
            //var year =
            var year = int.TryParse(inputYear, out int y1);
            IEnumerable<SaleModel> sales = services.ReadByYear(y1);
            if (sales == null)
            {
                Console.WriteLine("No Sales");

            } else
            {
                foreach (var item in sales)
                {
                    Console.WriteLine(item);

                }
            }
        }
        //-----read by year and month------//
        public void ReadByYearMonth()
        {

            Console.WriteLine("Please enter Year of items you want to list (YYYY):");
            string inputYear = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYear))
            {
                Console.WriteLine("You must enter a year value");
                inputYear = Console.ReadLine();
            }
            var year = int.TryParse(inputYear, out int y2);
            Console.WriteLine("Please enter Month of items you want to list (MM):");
            string inputMonth = Console.ReadLine();
            while (string.IsNullOrEmpty(inputMonth) || Convert.ToInt32(inputMonth) > 12 || Convert.ToInt32(inputMonth) < 0)
            {
                Console.WriteLine("Please enter valid month input that you want to list items from (MM):");
                inputMonth = Console.ReadLine();
            }
            var month = int.TryParse(inputMonth, out int m2);
            IEnumerable<SaleModel> sales = services.ReadByYearMonth(y2, m2);
            if (sales == null)
            {


                Console.WriteLine("No Sales");


            } else
            {
                foreach (var item in sales)
                {
                    Console.WriteLine(item);
                };
            }

        }

        //==============ALL THE TOTAL METHODS===============//
        //-----total by year------//
        public void TotalByYear()
        {

            Console.WriteLine("Please enter Year of sale you want total of (YYYY):");
            string inputYear = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYear))
            {
                Console.WriteLine("You must enter a year value");
                inputYear = Console.ReadLine();
            }
            var year = int.TryParse(inputYear, out int y3);
            if (year)
            {

                double? sales = services.TotalByYear(y3);
               

            }

        }
        //-----total by year and month------//
        public void TotalByYearMonth()
        {

            Console.WriteLine("Please enter Year of sale you want total of (YYYY):");
            string inputYear = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYear))
            {
                Console.WriteLine("You must enter a year value");
                inputYear = Console.ReadLine();
            }
            var year = int.TryParse(inputYear, out int y4);
            Console.WriteLine("Please enter Month of items you want total of (MM):");
            string inputMonth = Console.ReadLine();
            while (string.IsNullOrEmpty(inputMonth) || Convert.ToInt32(inputMonth) > 12 || Convert.ToInt32(inputMonth) < 0)
            {
                Console.WriteLine("Please enter valid month input for month that you want total from (MM):");
                inputMonth = Console.ReadLine();
            }
            var month = int.TryParse(inputMonth, out int m4);
            if (year && month)
            {

                double? sales = services.TotalByYearMonth(y4, m4);

            }

        }

        //==============ALL THE EXTRA METHODS===============//  
        //-----list between years------//
        public void ListBetweenYears()
        {

            Console.WriteLine("Please enter START YEAR that you want to list items from (YYYY):");
            string inputYearStart = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYearStart))
            {
                Console.WriteLine("You must enter a year value");
                inputYearStart = Console.ReadLine();
            }
            var yearstart = int.TryParse(inputYearStart, out int ys1);
            Console.WriteLine("Please enter END YEAR that you want to list items from (YYYY):");
            string inputYearEnd = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYearEnd))
            {
                Console.WriteLine("You must enter a year value");
                inputYearEnd = Console.ReadLine();
            }
            var yearend = int.TryParse(inputYearEnd, out int ye1);
            IEnumerable<SaleModel> sales = services.ListBetweenYears(ys1, ye1);
            if (sales == null)
            {
                Console.WriteLine("No Sales");

            }
            else
            {
                foreach (var item in sales)
                {
                    Console.WriteLine(item);

                }
            }
        }

        //-----list all sales between specified months and years------//
        public void ListBetweenYearsMonth()
        {

            Console.WriteLine("Please enter START YEAR that you want to list items from (YYYY):");
            string inputYearStart = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYearStart))
            {
                Console.WriteLine("You must enter a year value");
                inputYearStart = Console.ReadLine();
            }
            var yearstart = int.TryParse(inputYearStart, out int ys2);
            
            Console.WriteLine("Please enter START MONTH that you want to list items from (MM):");
            var inputMonthStart = Console.ReadLine();
            while (string.IsNullOrEmpty(inputMonthStart) || Convert.ToInt32(inputMonthStart) > 12 || Convert.ToInt32(inputMonthStart) < 0)
            {
                Console.WriteLine("Please enter valid month input for START MONTH that you want to list items from (MM):");
                inputMonthStart = Console.ReadLine();
            }
            var monthstart = int.TryParse(inputMonthStart, out int ms2);
            
            Console.WriteLine("Please enter END YEAR that you want to list items from (YYYY):");
            string inputYearEnd = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYearEnd))
            {
                Console.WriteLine("You must enter a year value");
                inputYearEnd = Console.ReadLine();
            }
            var yearend = int.TryParse(inputYearEnd, out int ye2);
            
            Console.WriteLine("Please enter END MONTH that you want to list items from (MM):");
            string inputMonthEnd = Console.ReadLine();
            while (string.IsNullOrEmpty(inputMonthEnd) || Convert.ToInt32(inputMonthEnd) > 12 || Convert.ToInt32(inputMonthEnd) < 0)
            {
                Console.WriteLine("Please enter valid month input for END MONTH that you want to list items from (MM):");
                inputMonthEnd = Console.ReadLine();
            }
            var monthend = int.TryParse(inputMonthStart, out int me2);
            IEnumerable<SaleModel> sales = services.ListBetweenYearsMonth(ys2, ye2, ms2, me2);

            if (sales == null)
            {
                Console.WriteLine("No Sales");

            }
            else
            {
                foreach (var item in sales)
                {
                    Console.WriteLine(item);

                }
            }
        }

        //-----average sales for a month between specified year range------//
        public void MonthAverage()
        {

            Console.WriteLine("Please enter START YEAR that you want to average sales from (YYYY):");
            string inputYearStart = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYearStart))
            {
                Console.WriteLine("You must enter a year value");
                inputYearStart = Console.ReadLine();
            }
            var yearStart = int.TryParse(inputYearStart, out int ys3);

            Console.WriteLine("Please enter END YEAR that you want average sales from (YYYY):");
            string inputYearEnd = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYearEnd))
            {
                Console.WriteLine("You must enter a year value");
                inputYearEnd = Console.ReadLine();
            }
            var yearEnd = int.TryParse(inputYearEnd, out int ye3);

            Console.WriteLine("Please enter Month of items you want average sales from (MM):");
            string inputMonth = Console.ReadLine();
            while (string.IsNullOrEmpty(inputMonth) || Convert.ToInt32(inputMonth) > 12 || Convert.ToInt32(inputMonth) < 0)
            {
                Console.WriteLine("Please enter valid month input for month that you want average sales from (MM):");
                inputMonth = Console.ReadLine();
            }
            var month = int.TryParse(inputMonth, out int m3);

            if (yearStart && yearEnd && month)
            {

                double? sales = services.MonthAverage(ys3, ye3, m3);

            }

        }

        //-----average sales for by month for a year------//
        public void YearByMonthAverage()
        {

            Console.WriteLine("Please enter Year that you want month average from (YYYY):");
            string inputYear = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYear))
            {
                Console.WriteLine("You must enter a year value");
                inputYear = Console.ReadLine();
            }
            var year = int.TryParse(inputYear, out int y4);
            if (year)
            {

                double? sales = services.YearByMonthAverage(y4);


            }

        }
        //-----month of a year that made the most sales ------//
        public void HighestMonthByYear()
        {

            Console.WriteLine("Please enter Year that you want highest month total from (YYYY):");
            string inputYear = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYear))
            {
                Console.WriteLine("You must enter a year value");
                inputYear = Console.ReadLine();
            }
            var year = int.TryParse(inputYear, out int y5);
            if (year)
            {

                double? sales = services.HighestMonthByYear(y5);


            }

        }
        //-----month of a year that made the least sales ------//
        public void LowestMonthByYear()
        {

            Console.WriteLine("Please enter Year that you want highest month total from (YYYY):");
            string inputYear = Console.ReadLine();
            while (string.IsNullOrEmpty(inputYear))
            {
                Console.WriteLine("You must enter a year value");
                inputYear = Console.ReadLine();
            }
            var year = int.TryParse(inputYear, out int y6);
            if (year)
            {

                double? sales = services.LowestMonthByYear(y6);


            }

        }






    }
}
