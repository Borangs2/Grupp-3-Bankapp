using System;

namespace Grupp_3_BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BankLogic test = new BankLogic();
            test.Startup();
            Program program = new Program();
            program.Menu();

        }
        public void Menu()
        {
            
            Console.WriteLine("Welcome to KYH BANK, please enter your Social Security number... (YYYYMMDDNNNN)");
            string prsnnmr = Console.ReadLine();
            int PrsnNumber = (int)Convert.ToInt64(prsnnmr);
            Console.WriteLine("Enter 1 to manage your account, 2 to edit your account, 3 to get quick info about your account or 4 to close KYH BANK.");
            Console.WriteLine("(for swedish please press 9)");
            string StringMenu1 = Console.ReadLine();
            int Choice = Convert.ToInt32(StringMenu1);
            switch (Choice)
            {
                case 1:
                    Console.WriteLine("Enter 1 to create a new account, 2 to see info about your account, 3 to deposit, 4 to withdraw or 5 to close an account.");
                    Console.WriteLine("(Enter 6 to get back to the main menu)");
                    string StringMenu3 = Console.ReadLine();
                    int NextChoice = Convert.ToInt32(StringMenu3);
                    switch (NextChoice)
                    {
                        case 1:
                            //AddNewAccount();
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
                            Menu();
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter 1 to change name or 2 to remove customer. ");
                    Console.WriteLine("(Enter 6 to get back to the main menu)");
                    string StringMenu2 = Console.ReadLine();
                    int NextChoice1 = Convert.ToInt32(StringMenu2);
                    switch (NextChoice1) { 
                        case 1:
                            //ChangeName();
                            break;
                        case 2:
                            //RemoveCustomer();
                            break;
                        case 3:
                            Menu();
                            break;
                    }
                    break;
                        case 3:
                    //GetCustomer();
                    break;
                case 4:
                    //CloseApp();
                    break;
               //case 6:
               //    
               //     break;
               //case 9:
               //    //ChangeLang();
               //    break;
            }
            if (Choice == 1111) //1111 = adminlösen
            {
                //Admin meny
                Console.WriteLine("1 add acc, 2 all customers, 3 main menu, 4 close.");
                string AdminMenu = Console.ReadLine();
                int AdminChoice = Convert.ToInt32(AdminMenu);
                switch (AdminChoice)
                {
                    case 1:
                        //addaccount();
                        break;
                    case 2:
                        //AllCustomers();
                        break;
                    case 3:
                        Menu();
                        break;
                    case 4:
                        //closeapp();
                        break;
                }
            }
        }
    }
}
