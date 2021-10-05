using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grupp_3_BankApp
{
    class BankLogic
    {









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

        //TODO: När customer klassen är klar lägg till detta
        private List<Customer> InterpretFile(List<string> CustomerFile)
        {
            throw new NotImplementedException();
            List<Customer> CustomerList = new List<Customer>();
            foreach(string customer in CustomerFile)
            {
                



            }
        }
        private List<string> ReadCustomerFile()
        {
            /*
             * File formating:
             * Namn - ååååmmddxxxx ; konto , saldo : konto2 , saldo
            */

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
