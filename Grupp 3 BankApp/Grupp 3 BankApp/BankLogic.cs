using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grupp_3_BankApp
{
    class BankLogic
    {







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
