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
    class Repository
    {


        private IList<SaleModel> sales;
        private static int counter = 0;

        //===========DATA ENTRY============//
        internal SaleModel Create(SaleModel toCreate)
        {
           
            SaleModel sale = new SaleModel();
            toCreate.ID = counter;
            counter++;
            sale.Name = toCreate.Name;
            sale.Quantity = toCreate.Quantity;
            sale.Price = toCreate.Price;
            sale.Date = toCreate.Date;
            return sale;






        }




    }
}
