﻿using System;

namespace Grupp_3_BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankLogic test = new BankLogic();
            test.Startup();
            Program program = new Program();
            program.Menu(test);
            //new Customer("andreas", "123456781234");
            
        }
        public void Menu(BankLogic bank)
        {
            
            Console.WriteLine("Welcome to KYH BANK, please enter your Social Security number... (YYYYMMDDXXXX)");
            string prsnnmr = Console.ReadLine();
            try
            {
                int PrsnNumber = (int)Convert.ToInt64(prsnnmr);
                Customer currentCustomer = bank.GetCustomer(prsnnmr);

                if (currentCustomer != null)
                {
                    while (true)
                    {
                        Console.WriteLine(
                        "1. Manage your accouont\n" +
                        "2. Edit your account\n" +
                        "3. View account\n" +
                        "4. Exit and Log out\n");

                        //Console.WriteLine("(for swedish please press 9)");
                        try
                        {
                            int stringMenu1 = Convert.ToInt32(Console.ReadLine());
                            switch (stringMenu1)
                            {
                                case 1:
                                    AccountMenu(currentCustomer);
                                    break;
                                case 2:
                                    ChangeAccountMenu();
                                    break;
                                case 3:
                                    //Get customer info
                                    Console.WriteLine(currentCustomer.FetchInfo(currentCustomer));
                                    break;
                                case 4:
                                    //Exit application
                                    Console.WriteLine("Thank you for using KYH bank. We hope to se you later");
                                    Environment.Exit(0);
                                    break;
                                case 6:
                                    AdminMenu(bank);
                                    //Admin meny                               
                                    break;
                                case 9:
                                    //ChangeLang();
                                    break;

                                default:
                                    Console.WriteLine("Unknown command");
                                    break;
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Please write a number listed above");
                        }


                        Console.WriteLine(" --- Press any key to continue --- ");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Your social security number was not found in the database of registered users");
                }
            }
            catch
            {
                Console.WriteLine("Write a number");
            }
            

            
            
        }
        private void AccountMenu(Customer customer)
        {
            Console.WriteLine(
                "What do you want to do?\n" +
                "1. Create a new account\n" +
                "2. View Accounts\n" +
                "3. Deposit into an account\n" +
                "4. Withdraw from an account\n" +
                "5. Close an account\n" +
                "6. Return to the main menu\n");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        int nyttKonto = customer.AddSavingsAccount(customer);
                        Console.WriteLine($"A new account with the account number {nyttKonto} has been created");
                        break;
                    case 2:
                        //GetCustomer();
                        break;
                    case 3:
                        //Insättning
                        break;
                    case 4:
                        //Uttag
                        break;
                    case 5:
                        //CloseAccount
                        break;
                    case 6:
                        return;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Please write a number listed above");
            }
        }
        private void ChangeAccountMenu()
        {
            Console.WriteLine(
                "1. Change your name\n" +
                "2. Delete your account\n" +
                "3. Return to main menu\n");
            string StringMenu2 = Console.ReadLine();
            try
            {
                int NextChoice1 = Convert.ToInt32(StringMenu2);
                switch (NextChoice1)
                {
                    case 1:
                        //ChangeName();
                        break;
                    case 2:
                        //RemoveCustomer();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Please write a number listed above");
            }
            
        }
        private void AdminMenu(BankLogic bank)
        {
            bank.AdminMenu();
        }
    }
}
