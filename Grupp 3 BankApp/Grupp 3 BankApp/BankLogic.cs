﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Grupp_3_BankApp
{
    class BankLogic
    {
        private static List<Customer> GlobalCustomerList { get; set; }
        private void CreateGlobalCustomerList()
        {
            if (!GlobalCustomerListCheck)
            {
                GlobalCustomerList = new List<Customer>();
                return;
            }
            GlobalCustomerListCheck = true;
        }

        private bool GlobalCustomerListCheck;



        //Lista med alla customers för användning i denna klass
        private string filePath = "Customers.txt";
        public BankLogic()
        {
            //Endast för testning
        }


        //* = färdigt men otestat
        //- = färdigt och testat

        //*
        //Fetches all customers name and PrsnNumber
        //Returns a List<string> with all customers name and prsnNumber
        //File format: "Name - PernNumber"
        private List<string> GetAllCustomers(List<Customer> GlobalCustomerList)
        {
            List<string> CustomerList = new List<string>();

            foreach (Customer customer in GlobalCustomerList)
            {
                string[] customerValues = new string[2] { customer.Name, customer.PrsnNumber };
                string.Join(" : ", customerValues);
            }
            return CustomerList;
        }

        //*
        //Fetches a customer from the the global customer list
        //Returns the customer of type Customer
        public Customer GetCustomer(string prsnNumber)
        {
            Customer thisCustomer;

            foreach(Customer customer in GlobalCustomerList)
            {
                
                if(customer.PrsnNumber == prsnNumber)
                {
                    thisCustomer = customer;
                    return thisCustomer;
                }
                
            }
            return null;


        }

        //TODO: När customer klassen är klar lägg till detta

        //*
        //Adds a new customer without any accounts to both files and object
        //Returns true if it succeded and false otherwise
        private bool AddCustomer(string name, string prsnNumber)
        {
            bool unique = true;
            foreach(Customer customer in GlobalCustomerList)
            {
                if (customer.PrsnNumber == prsnNumber)
                {
                    unique = false;
                }
            }
            if (unique)
            {
                File.AppendText($"{name} - {prsnNumber} ; ");
                new Customer(name, prsnNumber);
                return true;
            }

            return false;

        }

        //*
        //Changes a customers name in files and object
        //Returns true if it succeded and false otherwise
        public bool ChangeCustomerName(string newName, string prsnNumber) 
        {
            
            foreach(Customer customer in GlobalCustomerList)
            {              
                if (customer.PrsnNumber == prsnNumber)
                {
                    customer.Name = newName;
                    int index = GlobalCustomerList.IndexOf(customer);
                    GlobalCustomerList[index] = customer;


                    List<string> customerList = new List<string>(File.ReadAllLines(filePath));
                    List<string> customerAccounts = customer.GetAccountsToString(customer);
                    
                    string joined = string.Join(" : ", customerAccounts);

                    string changedLine = $"{customer.Name} - {customer.PrsnNumber} ; {joined}";
                    File.WriteAllLines(filePath, customerList);
                  
                    return true;
                }

                
            }         
            return false;
        }

        //*
        //Removes a customer from all files
        //Returns true if it succeded and flase otherwise
        public bool RemoveCustomer(string prsnNumber)
        {
            
            foreach (Customer customer in GlobalCustomerList)
            {
                if(customer.PrsnNumber == prsnNumber)
                {
                    //Hämta indexet
                    int index = GlobalCustomerList.IndexOf(customer);
                    //Ta bort Customer från globala listan
                    GlobalCustomerList.Remove(customer);

                    //Skapa och överför alla utom den som tas bort till textfilen
                    List<string> tempList = new List<string>(File.ReadAllLines(filePath));
                    List<string> newList = new List<string>();
                    for (int Line = 0; Line < tempList.Count; Line++)
                    {
                        if (Line != index)
                        {
                            newList.Add(tempList[Line]);
                        }
                        //När allt är implementerat se till att detta fungerar
                        File.WriteAllLines(filePath, newList);
                        return true;
                    }
                 }
            }
            return false;
        }

        //*
        //Creates a new savingsaccount in files
        //Returns the new account numbers
        public int AddSavingsAccount(Customer customer)
        {
            int index = GlobalCustomerList.IndexOf(customer);

            List<string> customerAccounts = new List<string>();
            foreach(SavingsAccount account in customer.Accounts)
            {
                customerAccounts.Add($"{account.Kontonummer} , {account.Saldo}");
            }

            //Get all data
            List<string> customerList = new List<string>(File.ReadAllLines(filePath));
            //Get all accounts in a single string
            string joined = string.Join(" : ", customerAccounts);

            string newLine = $"{customer.Name} - {customer.PrsnNumber} ; {joined}";

            customerList[index] = newLine;
            //File.WriteAllLines(filePath, customerList);

            int maxNummer = customerAccounts.Count + 1;
            customer.AddAccount(new SavingsAccount(customer, maxNummer + 1));

            return maxNummer + 1;
        }

        //*
        //Adds money to a customers account
        //Return true if it succeded otherwise false
        public bool Insättning(string prsnNumber, int kontoNummer, double kronor)
        {
            foreach (Customer customer in GlobalCustomerList)
            {
                if (customer.PrsnNumber == prsnNumber)
                {
                    foreach (SavingsAccount account in customer.Accounts)
                    {
                        try
                        {
                            account.Saldo += kronor;
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    break;
                }
            }
            return false;
        }

        //*
        //Withdraws money from a customers account
        //returns true if it succeded otherwise false
        public bool Uttag(string prsnNumber, int kontoNummer, double kronor)
        {
            foreach(Customer customer in GlobalCustomerList)
            {
                if(customer.PrsnNumber == prsnNumber)
                {
                   foreach(SavingsAccount account in customer.Accounts)
                    {
                        try
                        {
                            account.Saldo -= kronor;
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    break;
                }
            }
            return false;
        }

        //*
        //Call on startup to fetch and create files and the global customer list
        public bool Startup()
        {
            try
            {
                CreateGlobalCustomerList();

                InterpretFile(ReadCustomerFile());
                GlobalCustomerListCheck = true;
                return true;
            }
            catch
            {
                throw new FileErrorException();
            }
        }

        //Interprets the files read by the ReadCustomerFiles method
        //Returns a List<Customer> with every customer including accounts if any
        //Also this method sucks to work in and every problem i'm having leads back to it

        //TODO: Fixa så att customers bara får sina egna accounts istället för allas

        private List<Customer> InterpretFile(List<string> CustomerFile)
        {
            Console.WriteLine("Interpreting...");

            //Endast för testning
            //CustomerFile.Add("Andreas Boräng - 123456781234 ; 1 , 64362 : 2 , 52");

            List<Customer> CustomerList = new List<Customer>();
            string[] getName = new string[2];
            string[] getPrsnNumber = new string[2];
            List<SavingsAccount> getAccounts = new List<SavingsAccount>();

            string thisCustomer;
            for(int i = 0; i < CustomerFile.Count; i++)
            {
                thisCustomer = CustomerFile[i];
                getName = thisCustomer.Split(" - ");
                getPrsnNumber = getName[1].Split(" ; ");
                string[] tempAccount = getPrsnNumber[1].Split(" : ");
                getAccounts.Clear();
                foreach (string account in tempAccount)
                {
                    string[] thisAccount = account.Split(" , ");
                    int accountNumber = Convert.ToInt32(thisAccount[0]);
                    int saldo = Convert.ToInt32(thisAccount[1]);
                    getAccounts.Add(new SavingsAccount(accountNumber, saldo));
                }
                CustomerList.Add(new Customer(getName[0], getPrsnNumber[0], getAccounts));

            }

            foreach (Customer customer in CustomerList)
            {

                GlobalCustomerList.Add(customer);
            }

            return CustomerList;
        }
        
        //Reads the textfile and outputs it in raw data
        //Returns a List<string> with raw data to be interpreted
        //File foramat: "Namn - ååååmmddxxxx ; konto , saldo : konto2 , saldo"
        private List<string> ReadCustomerFile()
        {
            Console.WriteLine("Reading...");

            List<string> CustomerList;

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                return CustomerList = new List<string>();
            }
            CustomerList = new List<string>(File.ReadAllLines(filePath));
            return CustomerList;
        }
    }
    
    class FileErrorException : Exception
    {
        public FileErrorException() : base()
        {
            Console.WriteLine("File reading Error");
        }
    }
}
