﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grupp_3_BankApp
{
    class BankLogic
    {

        private List<Customer> GlobalCustomerList = new List<Customer>();          

        public BankLogic()
        {
            //Endast för testning
            //InterpretFile(ReadCustomerFile());
        }




        //*
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
        private Customer GetCustomer(string prsnNumber)
        {
            throw new NotImplementedException();
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


        public bool ChangeCustomerName(string newName, string prsnNumber) 
        {

            List<Customer> CustomerList = GlobalCustomerList;
            
            foreach(Customer customer in CustomerList)
            {              
                if (customer.PrsnNumber == prsnNumber)
                {



                    return true;
                }

                //Ändra filen
                
            }         
            return false;
        }

        public bool RemoveCustomer(int prsnNumber)
        {
            throw new NotImplementedException();
            /*
            foreach (Customer customer in GlobalCustomerList)
            {
                if(customer.PrsnNumber == prsnNumber)
                {
                    //Hämta indexet
                    int index = GlobalCustomerList.IndexOf(customer);
                    //Ta bort Customer från globala listan
                    GlobalCustomerList.Remove(customer);

                    //Skapa och överför alla utom den som tas bort till textfilen
                    List<string> tempList = new List<string>(File.ReadAllLines("customers.txt"));
                    List<string> newList = new List<string>();
                    for (int Line = 0; Line < tempList.Count; Line++)
                    {
                        if (Line != index)
                        {
                            newList.Add(tempList[Line]);
                        }
                        //När allt är implementerat se till att detta fungerar
                        File.WriteAllLines("customers.txt", newList);
                    }



                }
            }
            */

        }

        public int AddSavingsaccount(int prsnNumber)
        {
            //Kommer behövas ändras till List<Customer> när cusotmer klassen har pushats

            


            return 0;
        }

        //TODO: När customer klassen är klar lägg till detta
        private List<Customer> InterpretFile(List<string> CustomerFile)
        {
            Console.WriteLine("Interpreting...");

            CustomerFile.Add("Andreas Boräng - 123456781234 ; 1 , 64362 : 2 , 52");

            List<Customer> CustomerList = new List<Customer>();
            string[] getName = new string[2];
            string[] getPrsnNumber = new string[2];
            List<SavingsAccount> getAccounts = new List<SavingsAccount>();

            for(int i = 0; i < CustomerFile.Count; i++)
            {
                getName = CustomerFile[i].Split(" - ");
                getPrsnNumber = getName[1].Split(" ; ");
                string[] tempAccount = getPrsnNumber[1].Split(" : ");

                foreach (string account in tempAccount)
                {
                    int accountNumber = account[0];
                    int saldo = account[1];
                    getAccounts.Add(new SavingsAccount(accountNumber, saldo));
                }
            }

            foreach (string customer in CustomerFile)
            {
                //This causes an infinite loop and i dont know why
                CustomerList.Add(new Customer(getName[0], getPrsnNumber[0], getAccounts));

                GlobalCustomerList.Add(new Customer(getName[0], getPrsnNumber[0], getAccounts));
            }
            return CustomerList;
        }
        private List<string> ReadCustomerFile()
        {
            /*
             * File formating:
             * Namn - ååååmmddxxxx ; konto , saldo : konto2 , saldo
            */

            Console.WriteLine("Reading...");

            List<string> CustomerList;

            if (!File.Exists("Customers.txt"))
            {
                File.Create("Customers.txt");
                return CustomerList = new List<string>();
            }
            CustomerList = new List<string>(File.ReadAllLines("Customers.txt"));
            return CustomerList;
        }
    }
}
