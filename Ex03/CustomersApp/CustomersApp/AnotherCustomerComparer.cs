﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class AnotherCustomerComparer : IComparer<Customer>
    {
        public int Compare(Customer x, Customer y)
        {
            int answer = 1;
            if(y != null)
            {
                answer = x.Id - y.Id;
            }

            return answer;
        }
    }
}
