using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    class Account
    {
        private readonly int m_Id;
        private double m_Balance;
        internal Account(int i_Id)
        {
            m_Id = i_Id;
        }

        public int ID
        {
            get
            {
                return m_Id;
            }
        }

        public double Balance
        {
            get
            {
                return m_Balance;
            }
        }

        public void Deposit(double i_Amount)
        {
            if(i_Amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            m_Balance += i_Amount;
        }

        public void Withdraw(double i_Amount)
        {
            if (i_Amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(m_Balance - i_Amount < 0)
            {
                throw new InsufficientFundsException();
            }
            else 
            {
                m_Balance -= i_Amount;
            }
        }

        public void Transfer(Account I_AnotherAccount, double i_Amount)
        {
            try
            {
                Console.WriteLine("The balance before is: {0}$", Balance);
                Withdraw(i_Amount);          
                I_AnotherAccount.Deposit(i_Amount);                
            }
            finally
            {
                Console.WriteLine("Transfer attempt has been made.");
                Console.WriteLine("The balance after is: {0}$", Balance);
            }
        }
    }
}
