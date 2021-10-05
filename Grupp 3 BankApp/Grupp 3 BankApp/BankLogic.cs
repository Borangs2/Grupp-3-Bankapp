using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grupp_3_BankApp
{
    class BankLogic
    {
<<<<<<< HEAD
        public string Namn { get; set; }
        public string Efternamn { get; set; }
        public long Personnummer { get; set; }


 

        public bool ChangeCustomerName(string name, long pNr)
        {
            //byter namn på costumer genom pnr (true om namnet ändrades annars false)
        }

        public List<string> RemoveCustomer(long pNr)
        {
            // tar bort costumer genom pnr och alla comstumers konton, returnera lista på alla konton, saldo som de får (plus ränta)
        }

        public int AddSavingsAccount(long pNr)
        {
            //skapar konto med costumers pnr och returnerar den skapade kontons nummer
        }

        public string GetAccount(long pNr, int accountId)
        {
            //returnerar string med (kontonummer, saldo, kontotyp, räntesats) 
        }

        public bool Deposit(long pNr, int accountId, decimal amount)
        {
            //deposit med costumer pnr och accountid samt amout av deposit ( true om det gick annars false)
        }

        public bool Withdraw(long pNr, int accountId, decimal amount)
        {
            //whitdraw med costumer pnr och accountid samt amout av whitdraw ( true om det gick annars false)
        }

        public string CloseAccount(long pNr, int accountId)
        {
            Console.WriteLine("konto ");
            //stänger konto med costumer pnr och accid, returnerar saldo och ränta
=======









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
>>>>>>> 4434a37fe16d72a119b37182f8175b6fd86499a6
        }
    }
}
