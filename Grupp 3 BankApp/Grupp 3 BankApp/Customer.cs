using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp_3_BankApp
{
    class Customer : BankLogic
    {
        public string Name { get; set; } //Ex. John Doe
        public string PrsnNumber { get; } //Ex. 202012121234

        public List<SavingsAccount> Accounts { get; } = new List<SavingsAccount>();


        public Customer(string name, string id)
        {
            Name = name;
            PrsnNumber = id;
        }

        public Customer(string name, string id, List<SavingsAccount> accounts)
        {
            Name = name;
            PrsnNumber = id;
            Accounts = accounts;
        }

        public void AddAccount(SavingsAccount savingsAccount)
        {
            Accounts.Add(savingsAccount);

        }

        public void RemoveAccount(SavingsAccount savingsAccount)
        {
            Accounts.Remove(savingsAccount);
        }

        public void AddNewAccount()
        {
            Console.WriteLine("Type your Social Security Number (YYYYMMDDXXXX)");
            try
            {
                string prsnNumber = Console.ReadLine();
                var myAccount = new SavingsAccount();
                Accounts.Add(myAccount);
                AddSavingsAccount(prsnNumber);
            }
            catch
            {
                Console.WriteLine("Write a number");
            }



        }

        public void ChangeName()
        {
            Console.WriteLine("Type your Social Security Number (YYYYMMDDXXXX)");
            try
            {
                string prsnNumber = Console.ReadLine();
                Console.WriteLine("Type your name");
                Name = Console.ReadLine();

                ChangeCustomerName(Name, prsnNumber);
            }
            catch
            {
                Console.WriteLine("Write a number");
            }


        }

        public string FetchInfo()
        {
            var sb = new StringBuilder("Customer Name:" + Name);
            sb.Append("\nCustomer Id:" + PrsnNumber);

            foreach (var account in Accounts)
            {
                sb.Append("\nAccount:" + account);
            }

            return sb.ToString();
        }

        //public bool Deposit()
        // {
        //    Console.WriteLine("Type the Social Security Number (YYYYMMDDXXXX) to deposit money");
        //    try
        //     {
        //        string prsnNumber = Console.ReadLine();
        //        Console.WriteLine("Which account would you like to deposit to?");
        //        //Accounts = Console.ReadLine();
        //
        //        
        //     }
        //    catch
        //    {
        //        Console.WriteLine("Error");
        //         return false;

        //
        //
        //     return true;
        //  }

        //Returns a List<string> with all accounts in file formating:
        //Kontonamn , saldo : kontonamn , saldo : etc
        public List<string> GetAccountsToString(Customer customer)
        {
            List<string> accounts = new List<string>();
            foreach (SavingsAccount account in customer.Accounts)
            {
                accounts.Add($"{account.kontonummer} , {account.Saldo}");
            }
            return accounts;
        }

        
    }
}
