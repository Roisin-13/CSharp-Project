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



    }
}
