using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems
{
    public static class Semaphores
    {
        public static void CreateAccountAndWithDraw()
        {
            var account = new Account("Doe", "John");

            account.Deposit(100);

            double amountSue = 10;

            //Execute two threads in parallel
            var threads = new System.Threading.Thread[2];

            threads[0] = new System.Threading.Thread(()=> 
            {
                var before = account.Balance;
                account.Withdraw(amountSue);
                var after = account.Balance;

                if (Math.Abs(before-amountSue-after)>double.Epsilon)
                    Console.WriteLine("Thread problems");
            });


            threads[1] = new System.Threading.Thread(() =>
            {
                var before = account.Balance;
                account.Withdraw(amountSue);
                var after = account.Balance;

                if (Math.Abs(before - amountSue - after) > double.Epsilon)
                    Console.WriteLine("Thread problems");
            });

            Parallel.ForEach(threads, t =>
            {
                t.Start();
            });
        }

        public class Account{

            private int _userNumber;
            private string _userLastName;
            private string _userFirstName;
            private double _balance;

            public Account(string userLastName, string userFirstName)
            {
                _userFirstName = userFirstName;
                _userLastName = userLastName;
                _balance = 0;
            }
            public bool Deposit(double amount)
            {
                //Check that amount is positive 
                if (amount < 0) return false;

                //Deposit money
                _balance += amount;
                return true;
            }

            public bool Withdraw(double amount)
            {
                //Check that amount is positive 
                if (amount < 0) return false;

                //Check that there is enough money
                if (amount < _balance) return false;

                _balance -= amount;
                return true;
            }

            public double Balance
            {
                get { return _balance; }
            }
        }
    }
}
