using System;
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
            InterpretFile(ReadCustomerFile());
        }





        private List<string> GetAllCustomers(List<Customer> GlobalCustomerList)
        {
            throw new NotImplementedException();
            List<string> CustomerList = new List<string>();

            foreach (Customer customer in GlobalCustomerList)
            {
                //string[] customerValues = new string[2] { customer.Name, customer.PrsnNumber };
                //String.Join(" : ", customerValues);
            }
            return CustomerList;
        }

        private List<string> GetCustomer(List<Customer> GlobalCustomerList, int prsnNumber)
        {
            throw new NotImplementedException();
            List<string> CustomerList = new List<string>();

            foreach(Customer customer in GlobalCustomerList)
            {
                /*
                if(customer.PrsnNumber == prsnNumber)
                {
                    CustomerList.Add(customer.Name);
                    CustomerList.Add(customer.prsnNumber);

                    //TODO: Ändra Konton till dess riktiga namn
                    foreach(SavingsAccount account in customer.Konton)
                    {
                        CustomerList.Add(account);
                    }
                }
                */
            }


        }

        public bool ChangeCustomerName(string newName, int prsnNumber)
        {

            List<Customer> CustomerList = GlobalCustomerList;
            
            foreach(Customer customer in CustomerList)
            {
                /*
                if (customer.Prsnnumber == prsnNumber)
                {

                    Console.WriteLine("bra");



                }

                //Ändra filen
                */
            }         
            return false;
        }

        //TODO: När customer klassen är klar lägg till detta
        private List<Customer> InterpretFile(List<string> CustomerFile)
        {
            Console.WriteLine("Interpreting...");

            List<Customer> CustomerList = new List<Customer>();
            string[] getName = new string[2];
            string[] getPrsnNumber = new string[2];
            List<string> getAccounts = new List<string>();

            for(int i = 0; i < CustomerFile.Count; i++)
            {
                getName = CustomerFile[i].Split(" - ");
                getPrsnNumber = getName[1].Split(" ; ");
                string[] tempAccount = getPrsnNumber[1].Split(" : ");

                foreach (string account in tempAccount)
                {
                    getAccounts.Add(account);
                }
            }



            foreach(string customer in CustomerFile)
            {
                new Customer { 
                
                };
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
            string[] ReadCustomerFile = File.ReadAllLines("Customers.txt");
            CustomerList = new List<string>(ReadCustomerFile);
            return CustomerList;
        }
    }
}
