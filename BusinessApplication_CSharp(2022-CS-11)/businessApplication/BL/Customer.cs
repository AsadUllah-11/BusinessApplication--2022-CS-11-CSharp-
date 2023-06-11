using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessApplication.BL
{
    class Customer
    {
        public string customerName;
        public string customerDate;
        public Customer()
        {

        }
        public Customer (string customerName, string customerDate)
        {
            this.customerName = customerName;
            this.customerDate = customerDate;
        }
    }
}
