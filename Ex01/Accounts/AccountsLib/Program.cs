using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Account firstAcount = AccountFactory.CreateAccount(0);
            Account secondAcount = AccountFactory.CreateAccount(0);
            AccountOptionsMenu(firstAcount, secondAcount);
        }

        static void AccountOptionsMenu(Account i_MainAccount, Account i_AccountTotransferIfNeeded)
        {
            bool exit = false;
            Account firstAcount = i_MainAccount;
            Account secondAcount = i_AccountTotransferIfNeeded;
            int choose, amount;
            bool goodInput;
            string errotMsg = "You have entered a wrong value try again..";
            while (!exit)
            {
                goodInput = false;
                Console.WriteLine(
    @"Please choose: 
0.Transfer
1.Deposit
2.Withdraw 
3.Balance
4.exit");
                do
                {
                    goodInput = int.TryParse(Console.ReadLine(), out choose);
                    if (!goodInput)
                    {
                        Console.WriteLine(errotMsg);
                    }
                }
                while (!goodInput);

                Console.Clear();
                if(choose == 0)
                {
                    do
                    {
                        Console.Write("Please enter amount: ");
                        goodInput = int.TryParse(Console.ReadLine(), out amount);
                        goodInput = goodInput || amount < 0;
                        if (!goodInput)
                        {
                            Console.WriteLine(errotMsg);
                        }
                    }
                    while (!goodInput);

                    if(firstAcount.Transfer(secondAcount, amount))
                    {
                        Console.WriteLine("Successful");
                    }
                    else
                    {
                        Console.WriteLine("Invalid action not enough money");
                    }

                }
                else if (choose == 1)
                {
                    do
                    {
                        Console.Write("Please enter amount: ");
                        goodInput = int.TryParse(Console.ReadLine(), out amount);
                        goodInput = goodInput || amount < 0;
                        if (!goodInput)
                        {
                            Console.WriteLine(errotMsg);
                        }
                    }
                    while (!goodInput);

                    firstAcount.Deposit(amount);
                    Console.WriteLine("Successful");
                }
                else if (choose == 2)
                {
                    do
                    {
                        Console.Write("Please enter amount: ");
                        goodInput = int.TryParse(Console.ReadLine(), out amount);
                        goodInput = goodInput || amount < 0;
                        if (!goodInput)
                        {
                            Console.WriteLine(errotMsg);
                        }
                    }
                    while (!goodInput || amount < 0);

                    if (firstAcount.Withdraw(amount))
                    {
                        Console.WriteLine("Successful");
                    }
                    else
                    {
                        Console.WriteLine("Invalid action not enough money");
                    }
                }
                else if (choose == 3)
                {
                    Console.WriteLine("The balance is: {0}$", firstAcount.Balance);
                }
                else if (choose == 4)
                {
                    exit = true;
                }
            }

        }
    }
}
