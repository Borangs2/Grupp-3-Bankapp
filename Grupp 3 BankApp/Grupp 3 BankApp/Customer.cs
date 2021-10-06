﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp_3_BankApp
{
    class Customer : BankLogic
    {
        public string Name { get; set; } //Ex. John Doe
        public int PrsnNumber { get; } //Ex. 20201212-1234

        public List<SavingsAccount> Accounts { get; } = new List<SavingsAccount>();


        public Customer(string name, int id)
        {
            Name = name;
            PrsnNumber = id;
        }

        public Customer(string name, int id, List<SavingsAccount> accounts)
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
                int prsnNumber = Convert.ToInt32(Console.ReadLine());
                var myAccount = new SavingsAccount();
                Accounts.Add(myAccount);
                AddSavingsaccount(prsnNumber);
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
                int prsnNumber = Convert.ToInt32(Console.ReadLine());
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
    }
}
