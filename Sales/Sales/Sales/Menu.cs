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
                    Console.WriteLine("Please enter Menu option");
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
                        controller.Create();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("----Report Menu----");
                        Console.WriteLine("Please pick a menu option:");
                        Console.WriteLine("1. list sales by year");
                        Console.WriteLine("2. list sales by month and year");
                        Console.WriteLine("3. total sales by year");
                        Console.WriteLine("4. total sales by month and year");
                        Console.WriteLine("5. Enhanced Reports");
                        Console.WriteLine("6. Return to Main Menu");
                        bool inMenu2 = true;
                        while (inMenu2)
                        {
                            Console.WriteLine();
                            Console.Write("enter number > ");
                            string input2 = Console.ReadLine();
                            var a2 = int.TryParse(input2, out int id2);
                            if (!a2)
                            {
                                Console.WriteLine("Please enter Menu option");
                                continue;
                            }
                            if (id2 > 6)
                            {
                                Console.WriteLine("Invalid Input");
                                continue;
                            }
                            switch (id2)
                            {
                                case 1:
                                    controller.ReadByYear();
                                    break;
                                case 2:
                                    controller.ReadByYearMonth();
                                    break;
                                case 3:
                                    controller.TotalByYear();
                                    break;
                                case 4:
                                    controller.TotalByYearMonth();
                                    break;
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("----Enhanced Reports----");
                                    Console.WriteLine("Please pick a menu option:");
                                    Console.WriteLine("1. list all sales between specified year range");
                                    Console.WriteLine("2. list all sales between specified months and years");
                                    Console.WriteLine("3. average sales for a month between specified year range");
                                    Console.WriteLine("4. average sale by month for specified year");
                                    Console.WriteLine("5. return to Reports Menu");
                                    bool inMenu3 = true;
                                    while (inMenu3)
                                    {
                                        Console.WriteLine();
                                        Console.Write("enter number > ");
                                        string input3 = Console.ReadLine();
                                        var a3 = int.TryParse(input3, out int id3);
                                        if (!a3)
                                        {
                                            Console.WriteLine("Please enter Menu option");
                                            continue;
                                        }
                                        if (id3 > 5)
                                        {
                                            Console.WriteLine("Invalid Input");
                                            continue;
                                        }
                                        switch (id3)
                                        {
                                            case 1:
                                                Console.WriteLine("list all sales between specified year range");
                                                break;
                                            case 2:
                                                Console.WriteLine("list all sales between specified months and years");
                                                break;
                                            case 3:
                                                Console.WriteLine("average sales for a month between specified year range");
                                                break;
                                            case 4:
                                                Console.WriteLine("average sale by month for specified year");
                                                break;
                                            case 5:
                                                inMenu3 = false;
                                                continue;
                                        }
                                        
                                    }
                                    Console.Clear();
                                    Console.WriteLine("----Report Menu----");
                                    Console.WriteLine("Please pick a menu option:");
                                    Console.WriteLine("1. list sales by year");
                                    Console.WriteLine("2. list sales by month and year");
                                    Console.WriteLine("3. total sales by year");
                                    Console.WriteLine("4. total sales by month and year");
                                    Console.WriteLine("5. Enhanced Reports");
                                    Console.WriteLine("6. Return to Main Menu");
                                    break;
                                case 6:
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
