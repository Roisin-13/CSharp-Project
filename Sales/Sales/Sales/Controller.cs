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
            string name = Console.ReadLine();
            Console.WriteLine("Please enter quantity of product:");
            string quantityInput = Console.ReadLine();
            var quantity = int.Parse(quantityInput);
            Console.WriteLine("Please enter price of product (in pounds and pence):");
            string priceInput = Console.ReadLine();
            var price = double.Parse(priceInput);
            Console.WriteLine("Please enter date product was purchased:");
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

            Console.WriteLine("Please enter Year of items you want to list:");
            string inputYear = Console.ReadLine();
            var year = int.TryParse(inputYear, out int y1);
            if (year)
            {
                
                IEnumerable<SaleModel> sales = services.ReadByYear(y1);
                foreach (var item in sales)
                {
                    Console.WriteLine(item);
                }
                
            }

        }
        //-----read by year and month------//
        public void ReadByYearMonth()
        {

            Console.WriteLine("Please enter Year of items you want to list:");
            string inputYear = Console.ReadLine();
            var year = int.TryParse(inputYear, out int y2);
            Console.WriteLine("Please enter Month of items you want to list:");
            string inputMonth = Console.ReadLine();
            var month = int.TryParse(inputMonth, out int m2);
            if (year && month)
            {
                IEnumerable<SaleModel> sales = services.ReadByYearMonth(y2, m2);
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

            Console.WriteLine("Please enter Year of sale you want total of:");
            string inputYear = Console.ReadLine();
            var year = int.TryParse(inputYear, out int y3);
            if (year)
            {

                double sales3 = services.TotalByYear(y3);
                //foreach (var item in sales3)
                //{
                //    Console.WriteLine(item);
                //}

            }

        }
        //-----total by year and month------//
        public void TotalByYearMonth()
        {

            Console.WriteLine("Please enter Year of sale you want total of:");
            string inputYear = Console.ReadLine();
            var year = int.TryParse(inputYear, out int y4);
            Console.WriteLine("Please enter Month of items you want total of:");
            string inputMonth = Console.ReadLine();
            var month = int.TryParse(inputMonth, out int m4);
            if (year && month)
            {

                double sales4 = services.TotalByYearMonth(y4, m4);

            }

        }












    }
}
