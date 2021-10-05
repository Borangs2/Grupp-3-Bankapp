using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp_3_BankApp
{
    class BankLogic
    {
        public string Namn { get; set; }
        public string Efternamn { get; set; }
        public long Personnummer { get; set; }


        public List<string> GetCustomer(long pNr)
        {
            // returnerar list med info om costumer och deras konto 
            // först namn och pnr sen konto info
        }

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
        }
    }
}
