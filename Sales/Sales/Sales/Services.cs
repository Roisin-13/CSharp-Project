using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}
