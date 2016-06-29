using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public delegate bool CustomerFilter(Customer customer);

    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        private int _Id;
        private string _Address = string.Empty;
        private string _Name = string.Empty;

        public Customer()
        {
        }

        public Customer(int id, string address, string name)
        {
            _Id = id;
            _Address = address;
            _Name = name;
        }

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public int CompareTo(Customer other)
        {
            int answer = 1;         
            if (other == null)
            {
                answer = string.Compare(_Name, other.Name, true);
                //as I see it ,if strB does not have name/ref
                //strA is bigger 
            }

            return answer;
        }

        public bool Equals(Customer other)
        {
            bool answer = false;
                      
            if(other != null && string.Compare(_Name.ToLower(), other.Name.ToLower()) == 0 && _Id == other.Id)
            {
                answer = true;
            }

            return answer;
        }

        public override bool Equals(object obj)
        {
            bool answer = false;
            Customer otherCustomer = obj as Customer;
            if (otherCustomer != null && string.Compare(_Name.ToLower(), otherCustomer.Name.ToLower()) == 0 && _Id == otherCustomer.Id)
            {
                answer = true;
            }

            return answer;
        }

        public override int GetHashCode()
        {
            return (_Name.ToLower() + _Id.ToString()).GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(
@"Name: {0}.
Id: {1}.{2}", _Name, _Id, Environment.NewLine);
        }
    }
}
