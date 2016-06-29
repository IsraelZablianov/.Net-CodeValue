using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> listOfCustumers = new List<Customer>();
            listOfCustumers.Add(new Customer(1234, "Holon", "Israel"));
            listOfCustumers.Add(new Customer(1235, "Holon", "Beny"));
            listOfCustumers.Add(new Customer(1236, "Holon", "Jeny"));
            listOfCustumers.Add(new Customer(1237, "Holon", "Dany"));
            listOfCustumers.Add(new Customer(1238, "Holon", "Meny"));
            listOfCustumers.Add(new Customer(1239, "Holon", "Hany"));
            listOfCustumers.Add(new Customer(12, "Holon", "Nany"));
            listOfCustumers.Add(null);

            CustomerFilter Filter = FirstFilter;
            ICollection<Customer> newCustumers = GetCustomers(listOfCustumers, Filter);
            ICollection<Customer> newCustumers2 = GetCustomers(listOfCustumers,  
                delegate (Customer c) {
                    return FilterByLetters(c, 'L', 'Z');
                });

            ICollection<Customer> newCustumers3 = GetCustomers(listOfCustumers, custumer => { return custumer != null && custumer.Id < 100; });

            Console.WriteLine("====== A - K ====={0}", Environment.NewLine);
            foreach (var custumer in newCustumers)
            {
                if (custumer != null)
                {
                    Console.WriteLine(custumer.ToString());
                }
            }

            Console.WriteLine("====== L - Z ====={0}", Environment.NewLine);
            foreach (var custumer in newCustumers2)
            {
                if (custumer != null)
                {
                    Console.WriteLine(custumer.ToString());
                }
            }


            Console.WriteLine("====== Id < 100 ====={0}", Environment.NewLine);
            foreach (var custumer in newCustumers3)
            {
                if (custumer != null)
                {
                    Console.WriteLine(custumer.ToString());
                }
            }

            Console.ReadKey();
        }

        public static ICollection<Customer> GetCustomers(ICollection<Customer> listOfCustumers, CustomerFilter filter)
        {
            List<Customer> newListOfCustumers = null;
            if (listOfCustumers != null && filter != null)
            {
                newListOfCustumers = new List<Customer>();

                foreach (var custumer in listOfCustumers)
                {
                    if (filter(custumer))
                    {
                        newListOfCustumers.Add(custumer);
                    }
                }
            }

            return newListOfCustumers;
        }
        
        //static because I dont need an instance of this class.
        public static bool FirstFilter(Customer customer)
        {
            return FilterByLetters(customer, 'A', 'K');
        }

        public static bool FilterByLetters(Customer customer, char firstLetter, char secondtLetter)
        {
            bool answer = false;
            if (customer != null)
            {
                if (customer.Name[0] >= firstLetter && customer.Name[0] <= secondtLetter)
                {
                    answer = true;
                }
            }

            return answer;
        }
    }
}
