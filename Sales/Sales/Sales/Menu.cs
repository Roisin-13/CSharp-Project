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
    class Menu
    {
        private Controller controller;

        public Menu(Controller controller)
        {
            this.controller = controller;
        }

        public void firstMenu()
        {
            Console.Clear();
            Console.WriteLine("====MAIN MENU====");
            Console.WriteLine("Please pick a menu option:");
            Console.WriteLine("1. Data-Entry");
            Console.WriteLine("2. Reports");
            Console.WriteLine("3. Quit");

            bool inMenu = true;
            while (inMenu)
            {
                Console.WriteLine();
                Console.Write("enter number > ");
                string input = Console.ReadLine();
                var a = int.TryParse(input, out int id);
                if (!a)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                if (id >= 5)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                switch (id)
                {
                    case 1:
                        //Console.WriteLine("Data-Entry");
                        controller.Create();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Please pick a menu option:");
                        Console.WriteLine("1. list sales by year");
                        Console.WriteLine("2. list sales by month and year");
                        Console.WriteLine("3. total sales by year");
                        Console.WriteLine("4. total sales by month and year");
                        Console.WriteLine("5. Return to Main Menu");
                        bool inMenu2 = true;
                        while (inMenu2)
                        {
                            Console.WriteLine();
                            Console.Write("enter number > ");
                            string input2 = Console.ReadLine();
                            var a2 = int.TryParse(input2, out int id2);
                            if (!a2)
                            {
                                Console.WriteLine("Invalid Input");
                                continue;
                            }
                            if (id2 >= 6)
                            {
                                Console.WriteLine("Invalid Input");
                                continue;
                            }
                            switch (id2)
                            {
                                case 1:
                                    //Console.WriteLine("list sales by year");
                                    controller.ReadByYear();
                                    break;
                                case 2:
                                    //Console.WriteLine("list sales by month & year");
                                    controller.ReadByYearMonth();
                                    break;
                                case 3:
                                    //Console.WriteLine("total sales by year");
                                    controller.TotalByYear();
                                    break;
                                case 4:
                                    //Console.WriteLine("total sales by month and year");
                                    controller.TotalByYearMonth();
                                    break;
                                case 5:
                                    inMenu2 = false;
                                    continue;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("====MAIN MENU====");
                        Console.WriteLine("Please pick a menu option:");
                        Console.WriteLine("1. Data-Entry");
                        Console.WriteLine("2. Reports");
                        Console.WriteLine("3. Quit");
                        break;
                    case 3:
                        inMenu = false;
                        break;
                }

            }
        }






    }
}
