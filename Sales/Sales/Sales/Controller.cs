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
            //--quantity input
            Console.WriteLine("Please enter quantity of product:");
            var quantityInput = Console.ReadLine();
            try
            {
                
                while (string.IsNullOrEmpty(quantityInput) || Convert.ToInt32(quantityInput) < 0)
                {
                    Console.WriteLine("You must enter a valid quantity of product:");
                    quantityInput = Console.ReadLine();

                }
              
            }
            catch (FormatException)
            {
                while (!int.TryParse(quantityInput, out _)) { 
                    Console.WriteLine("You must enter a valid quantity of product:");
                    quantityInput = Console.ReadLine();
                }
            }
            var quantity = int.Parse(quantityInput);
            //--price input
            Console.WriteLine("Please enter price of product (in pounds and pence):");
            var priceInput = Console.ReadLine();
            try { 
            while (string.IsNullOrEmpty(priceInput) || Convert.ToDouble(priceInput) < 0)
            {
                Console.WriteLine("You must enter a valid price for product:");
                priceInput = Console.ReadLine();
            }
            }
            catch (FormatException)
            {
                while (!double.TryParse(priceInput, out _))
                {
                    Console.WriteLine("You must enter a valid price for product:");
                    priceInput = Console.ReadLine();
                }
            }
            var price = double.Parse(priceInput);
            //--date input
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
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;

            Console.WriteLine("Please enter Year of items you want to list (YYYY):");
            string inputYear = Console.ReadLine();
            try { 
            while (string.IsNullOrEmpty(inputYear) || Convert.ToInt32(inputYear) < 1900 || Convert.ToInt32(inputYear) > (Convert.ToInt32(yearNow) + 100))
            {
                Console.WriteLine("You must enter a valid year value");
                inputYear = Console.ReadLine();
            }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYear, out _))
                {
                    Console.WriteLine("You must enter a valid year value:");
                    inputYear = Console.ReadLine();
                }
            }
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
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;
            //--year input
            Console.WriteLine("Please enter Year of items you want to list (YYYY):");
            string inputYear = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYear) || Convert.ToInt32(inputYear) < 1900 || Convert.ToInt32(inputYear) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYear, out _))
                {
                    Console.WriteLine("You must enter a valid year value:");
                    inputYear = Console.ReadLine();
                }
            }
            var year = int.TryParse(inputYear, out int y2);
            //--month input
            Console.WriteLine("Please enter Month of items you want to list (MM):");
            string inputMonth = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputMonth) || Convert.ToInt32(inputMonth) > 12 || Convert.ToInt32(inputMonth) < 0)
                {
                    Console.WriteLine("Please enter valid month input that you want to list items from (MM):");
                    inputMonth = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputMonth, out _))
                {
                    Console.WriteLine("Please enter valid month input that you want to list items from (MM):");
                    inputMonth = Console.ReadLine();
                }
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
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;

            Console.WriteLine("Please enter Year of sale you want total of (YYYY):");
            string inputYear = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYear) || Convert.ToInt32(inputYear) < 1900 || Convert.ToInt32(inputYear) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYear, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
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
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;
            //--input year
            Console.WriteLine("Please enter Year of sale you want total of (YYYY):");
            string inputYear = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYear) || Convert.ToInt32(inputYear) < 1900 || Convert.ToInt32(inputYear) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
                
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYear, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
            }
            var year = int.TryParse(inputYear, out int y4);
            //--input month
            Console.WriteLine("Please enter Month of items you want total of (MM):");
            string inputMonth = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputMonth) || Convert.ToInt32(inputMonth) > 12 || Convert.ToInt32(inputMonth) < 0)
                {
                    Console.WriteLine("Please enter valid month input for month that you want total from (MM):");
                    inputMonth = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputMonth, out _))
                {
                    Console.WriteLine("Please enter valid month input for month that you want total from (MM):");
                    inputMonth = Console.ReadLine();
                }
            }
            var month = int.TryParse(inputMonth, out int m4);
            //--return
            if (year && month)
            {

                double? sales = services.TotalByYearMonth(y4, m4);

            }

        }

        //==============ALL THE EXTRA METHODS===============//  
        //-----list between years------//
        public void ListBetweenYears()
        {
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;
            //--input year start
            Console.WriteLine("Please enter START YEAR that you want to list items from (YYYY):");
            string inputYearStart = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYearStart) || Convert.ToInt32(inputYearStart) < 1900 || Convert.ToInt32(inputYearStart) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearStart = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYearStart, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearStart = Console.ReadLine();
                }
            }
            var yearstart = int.TryParse(inputYearStart, out int ys1);
            //--input end year start
            Console.WriteLine("Please enter END YEAR that you want to list items from (YYYY):");
            string inputYearEnd = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYearEnd) || Convert.ToInt32(inputYearEnd) < 1900 || Convert.ToInt32(inputYearEnd) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearEnd = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYearEnd, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearEnd = Console.ReadLine();
                }
            }
            var yearend = int.TryParse(inputYearEnd, out int ye1);
            //--return
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
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;
            //--input year start
            Console.WriteLine("Please enter START YEAR that you want to list items from (YYYY):");
            string inputYearStart = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYearStart) || Convert.ToInt32(inputYearStart) < 1900 || Convert.ToInt32(inputYearStart) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearStart = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYearStart, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearStart = Console.ReadLine();
                }
            }
            var yearstart = int.TryParse(inputYearStart, out int ys2);
            //--input month start
            Console.WriteLine("Please enter START MONTH that you want to list items from (MM):");
            var inputMonthStart = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputMonthStart) || Convert.ToInt32(inputMonthStart) > 12 || Convert.ToInt32(inputMonthStart) < 0)
                {
                    Console.WriteLine("Please enter valid month input for START MONTH that you want to list items from (MM):");
                    inputMonthStart = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputMonthStart, out _))
                {
                    Console.WriteLine("Please enter valid month input for START MONTH that you want to list items from (MM):");
                    inputMonthStart = Console.ReadLine();
                }
            }
            var monthstart = int.TryParse(inputMonthStart, out int ms2);
            //--input year end
            Console.WriteLine("Please enter END YEAR that you want to list items from (YYYY):");
            string inputYearEnd = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYearEnd) || Convert.ToInt32(inputYearEnd) < 1900 || Convert.ToInt32(inputYearEnd) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearEnd = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYearEnd, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearEnd = Console.ReadLine();
                }
            }
            var yearend = int.TryParse(inputYearEnd, out int ye2);
            //--input month end
            Console.WriteLine("Please enter END MONTH that you want to list items from (MM):");
            string inputMonthEnd = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputMonthEnd) || Convert.ToInt32(inputMonthEnd) > 12 || Convert.ToInt32(inputMonthEnd) < 0)
                {
                    Console.WriteLine("Please enter valid month input for END MONTH that you want to list items from (MM):");
                    inputMonthEnd = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputMonthEnd, out _))
                {
                    Console.WriteLine("Please enter valid month input for END MONTH that you want to list items from (MM):");
                    inputMonthEnd = Console.ReadLine();
                }
            }
            var monthend = int.TryParse(inputMonthEnd, out int me2);
            //--return
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
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;
            //--input year start
            Console.WriteLine("Please enter START YEAR that you want to average sales from (YYYY):");
            string inputYearStart = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYearStart) || Convert.ToInt32(inputYearStart) < 1900 || Convert.ToInt32(inputYearStart) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year  value");
                    inputYearStart = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYearStart, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearStart = Console.ReadLine();
                }
            }
            var yearStart = int.TryParse(inputYearStart, out int ys3);
            //--input end year
            Console.WriteLine("Please enter END YEAR that you want average sales from (YYYY):");
            string inputYearEnd = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYearEnd) || Convert.ToInt32(inputYearEnd) < 1900 || Convert.ToInt32(inputYearEnd) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearEnd = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYearEnd, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYearEnd = Console.ReadLine();
                }
            }
            var yearEnd = int.TryParse(inputYearEnd, out int ye3);
            //--input month
            Console.WriteLine("Please enter Month of items you want average sales from (MM):");
            string inputMonth = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputMonth) || Convert.ToInt32(inputMonth) > 12 || Convert.ToInt32(inputMonth) < 0)
                {
                    Console.WriteLine("Please enter valid month input for month that you want average sales from (MM):");
                    inputMonth = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputMonth, out _))
                {
                    Console.WriteLine("Please enter valid month input for month that you want average sales from (MM):");
                    inputMonth = Console.ReadLine();
                }
            }
            var month = int.TryParse(inputMonth, out int m3);
            //--return
            if (yearStart && yearEnd && month)
            {

                double? sales = services.MonthAverage(ys3, ye3, m3);

            }

        }

        //-----average sales for by month for a year------//
        public void YearByMonthAverage()
        {
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;
            //--input year
            Console.WriteLine("Please enter Year that you want month average from (YYYY):");
            string inputYear = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYear) || Convert.ToInt32(inputYear) < 1900 || Convert.ToInt32(inputYear) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYear, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
            }
            var year = int.TryParse(inputYear, out int y4);
            //--return
            if (year)
            {

                double? sales = services.YearByMonthAverage(y4);


            }

        }
        //-----month of a year that made the most sales ------//
        public void HighestMonthByYear()
        {
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;
            //--input year
            Console.WriteLine("Please enter Year that you want highest month total from (YYYY):");
            string inputYear = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYear) || Convert.ToInt32(inputYear) < 1900 || Convert.ToInt32(inputYear) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYear, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
            }
            var year = int.TryParse(inputYear, out int y5);
            //--return
            if (year)
            {

                double? sales = services.HighestMonthByYear(y5);


            }

        }
        //-----month of a year that made the least sales ------//
        public void LowestMonthByYear()
        {
            DateTime dateNow = DateTime.Now;
            int yearNow = dateNow.Year;
            //--input year
            Console.WriteLine("Please enter Year that you want highest month total from (YYYY):");
            string inputYear = Console.ReadLine();
            try
            {
                while (string.IsNullOrEmpty(inputYear) || Convert.ToInt32(inputYear) < 1900 || Convert.ToInt32(inputYear) > (Convert.ToInt32(yearNow) + 100))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                while (!int.TryParse(inputYear, out _))
                {
                    Console.WriteLine("You must enter a valid year value");
                    inputYear = Console.ReadLine();
                }
            }
            var year = int.TryParse(inputYear, out int y6);
            //--return
            if (year)
            {

                double? sales = services.LowestMonthByYear(y6);


            }

        }






    }
}
