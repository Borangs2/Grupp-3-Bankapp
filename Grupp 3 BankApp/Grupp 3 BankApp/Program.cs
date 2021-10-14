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
                        foreach (SavingsAccount account in customer.Accounts)
                        {
                            account.PrintAccountInfo();
                            Console.WriteLine("-------------------------------------------");
                        }
                        break;

                    case 3:
                        //Insättning
                        try
                        {
                            Console.WriteLine("write the account number to deposit: ");
                            int kontoNummer = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("How much money: ");
                            double kronor = Convert.ToDouble(Console.ReadLine());
                            if (customer.Insättning(customer.PrsnNumber, kontoNummer, kronor))
                            {
                                Console.WriteLine($"{kronor} has been deposited to your account");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("An error occured while depositing to your account \n " +
                                    "Are you sure you wrote the correct account number?");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Write a number");
                        }
                        break;
                        

                    case 4:
                        //Uttag
                        try
                        {
                            Console.WriteLine("write the account number to withdrawal: ");
                            int kontoNummer = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("How much money: ");
                            double kronor = Convert.ToDouble(Console.ReadLine());
                            bool succeded = customer.Uttag(customer.PrsnNumber, kontoNummer, kronor);
                            if (succeded)
                            {
                                Console.WriteLine($"{kronor} has been withdrawn from your account");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("An error occured while Withdrawing from your account\n" +
                                    "Are you sure you wrote the correct account number or wrote a number greater then the amount of money you have on your account?");
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Write a number");
                        }
                        break;

                    case 5:
                        //CloseAccount
                        customer.RemoveAccount(customer);
                        break;

                    case 6:
                        return;
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
                        Console.Write("Write your new name: ");
                        string newName = Console.ReadLine();
                        if(customer.ChangeCustomerName(newName, customer.PrsnNumber))
                        {
                            Console.WriteLine("Name changed successfully");
                        }
                        else
                        {
                            Console.WriteLine("An error occured while changing your name");
                        }
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
