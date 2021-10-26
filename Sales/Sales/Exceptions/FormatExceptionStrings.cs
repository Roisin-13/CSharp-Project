using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Exceptions
{
    class FormatExceptionStrings : Exception
    {
        public FormatExceptionStrings() : base()
        {
        }

        public FormatExceptionStrings(string message) : base(message)
        {
        }
    }
}
