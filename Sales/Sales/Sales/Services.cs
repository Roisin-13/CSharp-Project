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
    class Services
    {
        //------linking repository with services
        private readonly Repository repository;
        public Services(Repository repository)
        {
            this.repository = repository;
        }

        //===========DATA ENTRY============//
        internal SaleModel Create(SaleModel toCreate)
        {
            SaleModel newSale = repository.Create(toCreate);
            return newSale;

        }

        //==============ALL THE READ METHODS===============//
        //-----read by year------//
        internal IEnumerable<SaleModel> ReadByYear(int y1)
        {
            return repository.ReadByYear(y1);
        }
        //-----read by year and month------//
        internal IEnumerable<SaleModel> ReadByYearMonth(int y2, int m2)
        {
            return repository.ReadByYearMonth(y2, m2);
        }

        //==============ALL THE TOTAL METHODS===============//
        //-----total by year------//
        internal double? TotalByYear(int y3)
        {
            return repository.TotalByYear(y3);
        }
        //-----total by year and month------//
        internal double? TotalByYearMonth(int y4, int m4)
        {
            return repository.TotalByYearMonth(y4, m4);
        }

        //==============ALL THE EXTRA METHODS===============//  
        //-----list between years------//
        internal IEnumerable<SaleModel> ListBetweenYears(int ys1, int ye1)
        {
            return repository.ListBetweenYears(ys1, ye1);
        }
        //-----list all sales between specified months and years------//
        internal IEnumerable<SaleModel> ListBetweenYearsMonth(int ys2, int ye2, int ms2, int me2)
        {
            return repository.ListBetweenYearsMonth(ys2, ye2, ms2, me2);
        }
        //-----average sales for a month between specified year range------//
        internal double? MonthAverage(int ys3, int ye3, int m3)
        {
            return repository.MonthAverage(ys3, ye3, m3);
        }
        //-----average sales for by month for a year------//
        internal double? YearByMonthAverage(int y4)
        {
            return repository.YearByMonthAverage(y4);
        }
        //-----month of a year that made the most sales ------//
        internal double? HighestMonthByYear(int y5)
        {
            return repository.HighestMonthByYear(y5);
        }
        //-----month of a year that made the least sales ------//
        internal double? LowestMonthByYear(int y6)
        {
            return repository.LowestMonthByYear(y6);
        }



    }
}
