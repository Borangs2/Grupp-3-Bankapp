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

        //Oanvänd pga att den nollställer GlobalCustomerList av någon anledning
        public void AddNewAccount(Customer customer)
        {
            //Console.WriteLine("Type your Social Security Number (YYYYMMDDXXXX)");
            //try
            //{
            int accNum = AddSavingsAccount(customer);
            //    if (accNum < 0)
            //    {
            //        Console.WriteLine("Invalid Social security number");
            //        return;
            //    }

            //    var myAccount = new SavingsAccount(customer);
            //    Accounts.Add(myAccount);


            //    Console.WriteLine("An account has been created with the number: " + accNum);
            //}
            //catch
            //{
            //    Console.WriteLine("Write a number");
            //}
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

        public string FetchInfo(Customer customer)
        {
            string printLine = $"Name: {customer.Name}\n" +
                $"ID: {customer.PrsnNumber}\n";

            foreach(SavingsAccount accounts in customer.Accounts)
            {
                printLine += $"\n" +
                    $"Account ID: {accounts.Kontonummer}\n" +
                    $"Saldo: {accounts.Saldo}\n";
            }
            return printLine;
        }


        //Returns a List<string> with all accounts in file formating:
        //Kontonamn , saldo : kontonamn , saldo : etc
        public List<string> GetAccountsToString(Customer customer)
        {
            List<string> accounts = new List<string>();
            foreach (SavingsAccount account in customer.Accounts)
            {
                accounts.Add($"{account.Kontonummer} , {account.Saldo}");
            }
            return accounts;
        }

        
    }
}
