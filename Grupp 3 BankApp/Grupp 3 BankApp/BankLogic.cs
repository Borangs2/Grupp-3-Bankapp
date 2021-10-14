using System;
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

        //-
        public void AdminMenu()
        {   //om adminpass som är input = 1111 då körs admin menu.
            Console.WriteLine("Ange lösenord");
            string Adminpass = Console.ReadLine();
            if (Adminpass == "1111")
            {

                Console.WriteLine(
                    $"1. Add a customer\n" +
                    $"2. View All Customers\n" +
                    $"3. Go to the main menu\n" +
                    $"4. Close the application");
                string AdminMenu = Console.ReadLine();
                int AdminChoice = Convert.ToInt32(AdminMenu);
                switch (AdminChoice)
                {
                    case 1:
                        Console.Write("Add new customer name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Add new customer Social Security Number");
                        try
                        {
                            double prsnNumber = Convert.ToDouble(Console.ReadLine());
                            if (AddCustomer(name, Convert.ToString(prsnNumber)))
                            {
                                Console.WriteLine("Customer added Succesfully");
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Error in adding customer");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("SSN must be a number");
                        }
                        break;
                    case 2:
                        List<Customer> allCustomers = GetAllCustomers();
                        foreach (Customer Customer in allCustomers)
                        {
                            Console.WriteLine(
                                $"Name: {Customer.Name}\n" +
                                $"ID: {Customer.PrsnNumber}\n" +
                                $"Accounts:");
                            foreach (SavingsAccount account in Customer.Accounts)
                            {
                                Console.WriteLine(
                                    $"Account{account.Kontonummer} - Saldo: {account.Saldo}");
                            }
                            Console.WriteLine("------------------------------------");
                        }
                        return;
                    case 3:
                        return;
                    case 4:
                        Console.WriteLine("Thank you for using KYH bank. We hope to se you later");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wrong password, try again");
            }
        }


        //* = färdigt men otestat
        //- = färdigt och testat


        //-
        //Fetches all customers name and PrsnNumber
        //Returns a List<string> with all customers name and prsnNumber
        //File format: "Name - PernNumber"
        private List<Customer> GetAllCustomers()
        {
            return GlobalCustomerList;
        }

        //-
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
                List<string> newFile = ReadCustomerFile();
                newFile.Add($"{name} - {prsnNumber} ; ");
                File.WriteAllLines(filePath, newFile);
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
            if (!string.IsNullOrEmpty(newName))
            {
                foreach (Customer customer in GlobalCustomerList)
                {
                    if (customer.PrsnNumber == prsnNumber)
                    {
                        try
                        {
                            customer.Name = newName;
                            int index = GlobalCustomerList.IndexOf(customer);
                            GlobalCustomerList[index] = customer;


                            List<string> customerList = new List<string>(File.ReadAllLines(filePath));
                            List<string> customerAccounts = customer.GetAccountsToString(customer);

                            string joined = string.Join(" : ", customerAccounts);

                            string changedLine = $"{customer.Name} - {customer.PrsnNumber} ; {joined}";
                            customerList[index] = changedLine;
                            File.WriteAllLines(filePath, customerList);
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
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

        public bool RemoveAccountFromFile(Customer customer, int accountNmr)
        {
            try
            {
                List<string> tempList = new List<string>(File.ReadAllLines(filePath));
                //Get customer index
                int index = GlobalCustomerList.IndexOf(customer);

                //Ersätt filen med den nya listan utan kontot
                string newLine = $"{customer.Name} - {customer.PrsnNumber} ; ";
                List<string> newAccounts = new List<string>();
                foreach (SavingsAccount account in customer.Accounts)
                {
                    if (account.Kontonummer != accountNmr)
                    {
                        newAccounts.Add($"{account.Kontonummer} , {account.Saldo}");
                    }
                }
                newLine += string.Join(" : ", newAccounts);
                tempList[index] = newLine;

                File.WriteAllLines(filePath, tempList);
                return true;
            }
            catch
            {
                return false;
            }  
        }

        //*
        //Creates a new savingsaccount in files
        //Returns the new account number
        public int AddSavingsAccount(Customer customer)
        {
            int index = GlobalCustomerList.IndexOf(customer);

            //Get all data
            List<string> customerList = new List<string>(File.ReadAllLines(filePath));
            //Get all accounts in a single string

            int maxNummer = IncrementKontonummer(customer);
            customer.AddAccount(new SavingsAccount(customer, maxNummer));

            List<string> customerAccounts = new List<string>();
            foreach (SavingsAccount account in customer.Accounts)
            {
                customerAccounts.Add($"{account.Kontonummer} , {account.Saldo}");
            }

            string joined = string.Join(" : ", customerAccounts);
            string newLine = $"{customer.Name} - {customer.PrsnNumber} ; {joined}";

            customerList[index] = newLine;
            File.WriteAllLines(filePath, customerList);

            return maxNummer;
        }

        public int IncrementKontonummer(Customer customer)
        {
            int[] customerAccounts = new int[customer.Accounts.Count];
            int index = 0;
            foreach (SavingsAccount account in customer.Accounts)
            {
                customerAccounts[index] = account.Kontonummer;
            }
            int maxNummer;
            try
            {
                maxNummer = customerAccounts.Max();
            }
            catch
            {
                maxNummer = 1000;
            }
            return maxNummer + 1;
        }

        //*
        //Adds money to a customers account
        //Return true if it succeded otherwise false
        public bool Insättning(string prsnNumber, int kontoNummer, double kronor)
        {
            bool succeded = false;
            foreach (Customer customer in GlobalCustomerList)
            {
                if (customer.PrsnNumber == prsnNumber)
                {
                    foreach (SavingsAccount account in customer.Accounts)
                    {
                        if(account.Kontonummer == kontoNummer)
                        {                            
                            account.Saldo += kronor;
                            succeded = true;
                            break;                      
                        }
                    }
                    //Update the file
                    int index = GlobalCustomerList.IndexOf(customer);
                    List<string> customerList = new List<string>(File.ReadAllLines(filePath));
                    List<string> customerAccounts = new List<string>();

                    foreach (SavingsAccount account in customer.Accounts)
                    {
                        customerAccounts.Add($"{account.Kontonummer} , {account.Saldo}");
                    }

                    string joined = string.Join(" : ", customerAccounts);
                    string newLine = $"{customer.Name} - {customer.PrsnNumber} ; {joined}";

                    customerList[index] = newLine;
                    File.WriteAllLines(filePath, customerList);
                    if (succeded)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //*
        //Withdraws money from a customers account
        //returns true if it succeded otherwise false
        public bool Uttag(string prsnNumber, int kontoNummer, double kronor)
        {
            bool succeded = false;
            foreach (Customer customer in GlobalCustomerList)
            {
                if (customer.PrsnNumber == prsnNumber)
                {
                    foreach (SavingsAccount account in customer.Accounts)
                    {
                        if (account.Kontonummer == kontoNummer)
                        {
                            if (account.Saldo > kronor)
                            {
                                account.Saldo -= kronor;
                                succeded = true;
                                break;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    //Update the file
                    int index = GlobalCustomerList.IndexOf(customer);
                    List<string> customerList = new List<string>(File.ReadAllLines(filePath));
                    List<string> customerAccounts = new List<string>();

                    foreach (SavingsAccount account in customer.Accounts)
                    {
                        customerAccounts.Add($"{account.Kontonummer} , {account.Saldo}");
                    }

                    string joined = string.Join(" : ", customerAccounts);
                    string newLine = $"{customer.Name} - {customer.PrsnNumber} ; {joined}";

                    customerList[index] = newLine;
                    File.WriteAllLines(filePath, customerList);
                    if (succeded)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //*
        //Call on startup to fetch and create files and the global customer list
        public bool Startup()
        {
            //try
            //{
            CreateGlobalCustomerList();

            InterpretFile(ReadCustomerFile());
            GlobalCustomerListCheck = true;
            return true;
            //}
            //catch
            //{
            //    throw new FileErrorException();
            //}
        }

        //Interprets the files read by the ReadCustomerFiles method
        //Returns a List<Customer> with every customer including accounts if any
        //Also this method sucks to work in and every problem i'm having leads back to it
        private List<Customer> InterpretFile(List<string> CustomerFile)
        {
            Console.WriteLine("Interpreting...");
            GlobalCustomerList.Clear();
            //Endast för testning
            //CustomerFile.Add("Andreas Boräng - 123456781234 ; 1 , 64362 : 2 , 52");

            List<Customer> CustomerList = new List<Customer>();
            string[] getName = new string[2];
            string[] getPrsnNumber = new string[2];

            for (int i = 0; i < CustomerFile.Count; i++)
            {
                string thisCustomer = CustomerFile[i];
                getName = thisCustomer.Split(" - ");
                getPrsnNumber = getName[1].Split(" ; ");
                string[] tempAccount = getPrsnNumber[1].Split(" : ");

                List<SavingsAccount> getAccounts = new List<SavingsAccount>();

                if (!string.IsNullOrEmpty(tempAccount[0]))
                {
                    getAccounts.Clear();
                    foreach (string account in tempAccount)
                    {
                        string[] thisAccount = account.Split(" , ");
                        int accountNumber = Convert.ToInt32(thisAccount[0]);
                        int saldo = Convert.ToInt32(thisAccount[1]);
                        getAccounts.Add(new SavingsAccount(accountNumber, saldo));
                    }
                }
                Customer newCustomer = new Customer(getName[0], getPrsnNumber[0], getAccounts);
                CustomerList.Add(new Customer(getName[0], getPrsnNumber[0], getAccounts));
                GlobalCustomerList.Add(newCustomer);
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
