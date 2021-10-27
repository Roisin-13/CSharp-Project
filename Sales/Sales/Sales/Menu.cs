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
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine("====MAIN MENU====");
                Console.WriteLine("Please pick a menu option:");
                Console.WriteLine("1. Data-Entry");
                Console.WriteLine("2. Reports");
                Console.WriteLine("3. QUIT");
                Console.WriteLine();
                Console.Write("enter number > ");
                string input = Console.ReadLine();
                var a = int.TryParse(input, out int id);
                if (!a)
                {
                    Console.WriteLine("You must enter a Menu option");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to Menu");
                    Console.ReadLine();
                    inMenu = true;
                    continue;
                }
                if (id >= 5)
                {
                    Console.WriteLine("Not a valid Menu option");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to Menu");
                    Console.ReadLine();
                    inMenu = true;
                    continue;
                }
                switch (id)
                {
                    case 1:
                        controller.Create();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to Menu");
                        Console.ReadLine();
                        inMenu = true;
                        break;
                    case 2:
                        bool inMenu2 = true;
                        while (inMenu2)
                        {
                            Console.Clear();
                            Console.WriteLine("----REPORT MENU----");
                            Console.WriteLine("Please pick a menu option:");
                            Console.WriteLine("1. list sales by year");
                            Console.WriteLine("2. list sales by month and year");
                            Console.WriteLine("3. total sales by year");
                            Console.WriteLine("4. total sales by month and year");
                            Console.WriteLine("5. ENHANCED REPORTS");
                            Console.WriteLine("6. Return to MAIN MENU");
                            Console.WriteLine();
                            Console.Write("enter number > ");
                            string input2 = Console.ReadLine();
                            var a2 = int.TryParse(input2, out int id2);
                            if (!a2)
                            {
                                Console.WriteLine("You must enter a Menu option");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to Menu");
                                Console.ReadLine();
                                inMenu2 = true;
                                continue;
                            }
                            if (id2 > 6)
                            {
                                Console.WriteLine("Not a valid Menu option");
                                Console.WriteLine();
                                Console.WriteLine("Press any key to return to Menu");
                                Console.ReadLine();
                                inMenu2 = true;
                                continue;
                            }
                            switch (id2)
                            {
                                case 1:
                                    controller.ReadByYear();
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to return to Menu");
                                    Console.ReadLine();
                                    inMenu2 = true;
                                    break;
                                case 2:
                                    controller.ReadByYearMonth();
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to return to Menu");
                                    Console.ReadLine();
                                    inMenu2 = true;
                                    break;
                                case 3:
                                    controller.TotalByYear();
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to return to Menu");
                                    Console.ReadLine();
                                    inMenu2 = true;
                                    break;
                                case 4:
                                    controller.TotalByYearMonth();
                                    Console.WriteLine();
                                    Console.WriteLine("Press any key to return to Menu");
                                    Console.ReadLine();
                                    inMenu2 = true;
                                    break;
                                case 5:
                                    bool inMenu3 = true;
                                    while (inMenu3)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("----ENHANCED REPORTS----");
                                        Console.WriteLine("Please pick a menu option:");
                                        Console.WriteLine("1. list all sales between specified year range");
                                        Console.WriteLine("2. list all sales between specified months and years");
                                        Console.WriteLine("3. average sales for a month between specified year range");
                                        Console.WriteLine("4. average sale by month for specified year");
                                        Console.WriteLine("5. total of the month of a specified year which made the most sales");
                                        Console.WriteLine("6. total of the month of a specified year which made the least sales");
                                        Console.WriteLine("7. return to REPORTS MENU");
                                        Console.WriteLine();
                                        Console.Write("enter number > ");
                                        string input3 = Console.ReadLine();
                                        var a3 = int.TryParse(input3, out int id3);
                                        if (!a3)
                                        {
                                            Console.WriteLine("You must enter a Menu option");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to return to Menu");
                                            Console.ReadLine();
                                            inMenu3 = true;
                                            continue;
                                        }
                                        if (id3 > 7)
                                        {
                                            Console.WriteLine("Not a valid Menu option");
                                            Console.WriteLine();
                                            Console.WriteLine("Press any key to return to Menu");
                                            Console.ReadLine();
                                            inMenu3 = true;
                                            continue;
                                        }
                                        switch (id3)
                                        {
                                            case 1:
                                                controller.ListBetweenYears();
                                                Console.WriteLine();
                                                Console.WriteLine("Press any key to return to Menu");
                                                Console.ReadLine();
                                                inMenu3 = true;
                                                break;
                                            case 2:
                                                controller.ListBetweenYearsMonth();
                                                Console.WriteLine();
                                                Console.WriteLine("Press any key to return to Menu");
                                                Console.ReadLine();
                                                inMenu3 = true;
                                                break;
                                            case 3:
                                                controller.MonthAverage();
                                                Console.WriteLine();
                                                Console.WriteLine("Press any key to return to Menu");
                                                Console.ReadLine();
                                                inMenu3 = true;
                                                break;
                                            case 4:
                                                controller.YearByMonthAverage();
                                                Console.WriteLine();
                                                Console.WriteLine("Press any key to return to Menu");
                                                Console.ReadLine();
                                                inMenu3 = true;
                                                break;
                                            case 5:
                                                controller.HighestMonthByYear();
                                                Console.WriteLine();
                                                Console.WriteLine("Press any key to return to Menu");
                                                Console.ReadLine();
                                                inMenu3 = true;
                                                break;
                                            case 6:
                                                controller.LowestMonthByYear();
                                                Console.WriteLine();
                                                Console.WriteLine("Press any key to return to Menu");
                                                Console.ReadLine();
                                                inMenu3 = true;
                                                break;
                                            case 7:
                                                inMenu3 = false;
                                                continue;
                                        }
                                        
                                    }
                                    break;
                                case 6:
                                    inMenu2 = false;
                                    continue;
                            }
                        }
                        break;
                    case 3:
                        inMenu = false;
                        break;
                }

            }
        }






    }
}
