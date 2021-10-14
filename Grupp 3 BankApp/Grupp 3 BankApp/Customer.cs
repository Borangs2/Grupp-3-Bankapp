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

        public void RemoveAccount(Customer customer)
        {
            Console.WriteLine("What account do you wish to remove: ");
            try
            {
                int removeAccount = Convert.ToInt32(Console.ReadLine());
                if (RemoveAccountFromFile(customer, removeAccount))
                {
                    SavingsAccount thisAccount = null;
                    for(int index = 0; index < customer.Accounts.Count; index++)
                    {
                        if(Accounts[index].Kontonummer == removeAccount)
                        {
                            thisAccount = customer.Accounts[index];
                            customer.Accounts.Remove(thisAccount);
                            Console.WriteLine("Account removed Succesfully");
                            //return true;
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Applikation encountered an error removeing the account");
                }
            }
            catch
            {
                Console.WriteLine("Please write a number");
            }
            

        }

        //Oanvänd pga att den nollställer GlobalCustomerList av någon anledning
        public void AddNewAccount(Customer customer)
        {
            int accNum = AddSavingsAccount(customer);
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
