using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Grupp_3_BankApp
{
class SavingsAccount
    {

        private protected double kontosaldo;
        public double Saldo
        {
            get { return kontosaldo; }
            set { if (value >= 0) kontosaldo = value; }
        }

        public SavingsAccount(Customer customer, int kontonummer)
        {
            kontonummer = IncrementKontonummer(customer);
            Saldo = 0;
        }

        public SavingsAccount(int kontonummer, int saldo)
        {
            _Kontonummer = kontonummer;
            Saldo = saldo;
        }

        private protected int _Kontonummer;        // det här objektets kontonummer
        public int Kontonummer
        {

            get { return _Kontonummer; }
            set { _Kontonummer = value; }
        }



        private protected double kontoräntesats = 1.0;
        public double räntesats
        {
            get { return kontoräntesats; }
            set { kontoräntesats = value; }
        }

        public double ränta
        {
            get { return kontosaldo * (kontoräntesats / 100); }
        }

        public string kontotyp = "sparkonto";

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Kontonummer: {_Kontonummer} \n" +
                $"Saldo: {kontosaldo} \n" +
                $"Kontotyp: Sparkonto \n" +
                $"Räntesats: {kontoräntesats}%");
        }

        public int IncrementKontonummer(Customer customer)
        {
            int[] customerAccounts = new int[customer.Accounts.Count];
            int index = 0;
            foreach (SavingsAccount account in customer.Accounts)
            {
                customerAccounts[index] = account._Kontonummer;
            }
            int maxNummer;
            try
            {
                maxNummer = customerAccounts.Max();
            }
            catch
            {
                maxNummer = 0;
            }
            return maxNummer + 1;
        }

        
    }
}
