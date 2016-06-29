using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    static class AccountFactory
    {
        private static int m_Id = 12345;
        public static Account CreateAccount(double I_Balance)
        {
            Account account = new Account(m_Id);
            account.Deposit(I_Balance);
            m_Id++;
            return account;
        }
    }
}
