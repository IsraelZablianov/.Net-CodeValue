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
            m_Balance += i_Amount;
        }

        public bool Withdraw(double i_Amount)
        {
            bool succeed = false;
            if (m_Balance - i_Amount > 0)
            {
                succeed = true;
                m_Balance -= i_Amount;
            }

            return succeed;
        }

        public bool Transfer(Account I_AnotherAccount, double i_Amount)
        {
            bool succeed = false;
            if (this.Withdraw(i_Amount))
            {
                succeed = true;
                I_AnotherAccount.Deposit(i_Amount);
            }

            return succeed;
        }

    }
}
