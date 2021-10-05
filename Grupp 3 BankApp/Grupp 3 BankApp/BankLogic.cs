using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Grupp_3_BankApp
{
    class BankLogic
    {





    }


    private List<string> ReadCustomerFile()
    {
        /*
         * File formating:
         * Namn - ååååmmddxxxx ; konto , saldo : konto2 , saldo
        */

        List<string> CustomerList = new List<string>();

        if (!File.Exists("Customers.txt"))
        {
            File.Create("Customers.txt");
            return CustomerList;
        }
        return CustomerList;
    }



}
