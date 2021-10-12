using System;

namespace Grupp_3_BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankLogic bank = new BankLogic();
            bank.Startup();
            Program program = new Program();
            program.Menu(bank);
        }
        public void Menu(BankLogic bank)
        {
            
            Console.WriteLine("Welcome to KYH BANK, please enter your Social Security number... (YYYYMMDDXXXX)");
            string prsnNmr = Console.ReadLine();
            try
            {
                Customer currentCustomer = bank.GetCustomer(prsnNmr);

                if (currentCustomer != null)
                {
                    while (true)
                    {
                        Console.WriteLine(
                        "1. Manage your accouont\n" +
                        "2. Edit your account\n" +
                        "3. View account\n" +
                        "4. Exit and Log out\n");

                        try
                        {
                            int stringMenu1 = Convert.ToInt32(Console.ReadLine());
                            switch (stringMenu1)
                            {
                                case 1:
                                    AccountMenu(currentCustomer);
                                    break;
                                case 2:
                                    ChangeAccountMenu(currentCustomer);
                                    break;
                                case 3:
                                    //Get customer info
                                    Console.WriteLine(currentCustomer.FetchInfo(currentCustomer));
                                    break;
                                case 4:
                                    //Exit application
                                    Console.WriteLine("Thank you for using KYH bank. We hope to see you later");
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
                            Console.WriteLine("Please write one of the numbers listed above");
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
                        foreach(SavingsAccount account in customer.Accounts)
                        {
                            account.PrintAccountInfo();
                            Console.WriteLine("-------------------------------------------");
                        }
                        break;
                    case 3:
                        //Insättning

                        Console.WriteLine("write the account number to deposit: ");
                        int kontoNummer = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("How much money: ");
                        double kronor = Convert.ToDouble(Console.ReadLine());
                        customer.Insättning(customer.PrsnNumber, kontoNummer, kronor);
                        
                        break;
                    case 4:
                        //Uttag
                        Console.WriteLine("write the account number to withdrawal: ");
                        kontoNummer = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("How much money: ");
                        kronor = Convert.ToDouble(Console.ReadLine());
                        customer.Uttag(customer.PrsnNumber, kontoNummer, kronor);
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
                Console.WriteLine("Please write one of the numbers listed above");
            }
        }
        private void ChangeAccountMenu(Customer customer)
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
                        string newName = Console.ReadLine();
                        customer.ChangeCustomerName(newName, customer.PrsnNumber);
                        break;
                    case 2:
                        //RemoveCustomer();
                        customer.RemoveCustomer(customer.PrsnNumber);
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
                Console.WriteLine("Please write one of the numbers listed above");
            }
            
        }
        private void AdminMenu(BankLogic bank)
        {
            bank.AdminMenu();
        }
    }
}
