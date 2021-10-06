using System;
using System.Collections.Generic;
using System.Text;

namespace Grupp_3_BankApp
{
class SavingsAccount : BankLogic
    {

        private protected double kontosaldo;
        public double Saldo
        {
            get { return kontosaldo; }
            set { if (value >= 0) kontosaldo = value; }
        }

        public SavingsAccount()
        {
            global_kontonummer++;
            Kontonummer = global_kontonummer;
        }

        public SavingsAccount(int kontonummer, int saldo)
        {
            Kontonummer = kontonummer;
            Saldo = saldo;
        }

        
        /*
        private protected string kontonamn;
        public string namn
        {
            get { return kontonamn; }
            set { if (value != "") kontonamn = value; }
        }
        */

        private static int global_kontonummer = 1000;   // samma variabel för alla SavingsAccount objekt
        private protected int Kontonummer;        // det här objektets kontonummer
        public int kontonummer
        {

            get { return Kontonummer; }
            set { Kontonummer = value; }
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

        public double Insättning(double kronor)
        {
            kontosaldo += kronor;
            return kontosaldo;
        }

        public double Uttag(double kronor)
        {
            kontosaldo -= kronor;
            return kontosaldo;
        }

        public override string ToString()
        {
            return $"kontonummer: {Kontonummer} \n" +
                $"saldo: {kontosaldo} \n" +
                $"kontotyp: Sparkonto" +
                $"\nkontotyp: {kontoräntesats}";
        }
    }
}
