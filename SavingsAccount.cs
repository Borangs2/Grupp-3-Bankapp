using System;

// SavingsAccount class
// Lucas Blomhäll

namespace ConsoleAppBankapp
{
    class SavingsAccount
    {
        public SavingsAccount()
        {
            global_kontonummer++;
            konto_kontonummer = global_kontonummer;
        }
        private protected double kontosaldo;
        public double saldo
        {
            get { return kontosaldo; }
            set { if (value >= 0) kontosaldo = value; }
        }

        private protected string kontonamn;
        public string namn
        {
            get { return kontonamn; }
            set { if (value != "") kontonamn = value; }
        }

        private static int global_kontonummer = 1000;   // samma variabel för alla SavingsAccount objekt
        private protected int konto_kontonummer;        // det här objektets kontonummer
        public int kontonummer
        {

            get { return konto_kontonummer; }
            set { konto_kontonummer = value; }
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
            return "Namn: " + kontonamn + "\nkontonummer: " + konto_kontonummer + "\nsaldo: " + kontosaldo + "\nkontotyp: " + "sparkonto" + "\nkontotyp: " + kontoräntesats;
        }
    }
}