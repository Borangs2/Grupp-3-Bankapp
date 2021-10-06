using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp_3_BankApp
{
    class Customer
    {
        public string Name { get; set; } //Ex. John Doe
        public string PrsnNumber { get; } //Ex. 20201212-1234

        public List<SavingsAccount> Accounts { get; } = new List<SavingsAccount>();


        public Customer(string id)
        {
            PrsnNumber = id;
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
            var myAccount = new SavingsAccount();
            Accounts.Add(myAccount);
        }

        public void ChangeName()
        {
            Console.WriteLine("Type your name");
            Name = Console.ReadLine();
            
        }

        public string FetchInfo()
        {
            var sb = new StringBuilder("Customer Name:" + Name);
            sb.Append("\nCustomer Id:" + Id);

            foreach (var account in Accounts)
            {
                sb.Append("\nAccount:" + account);
            }

            return sb.ToString();
    }
}
