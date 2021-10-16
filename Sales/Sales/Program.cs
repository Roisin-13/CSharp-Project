using Sales.Sales;
using System;

namespace Sales
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            firstMenu();
            
        }
        public static void firstMenu()
        {
            Menu menu = new Menu();
            menu.firstMenu();
        }

    }
}
