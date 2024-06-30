using Banking.models;
using System;

namespace Banking.views
{
    internal class PersonPage
    {
        private const decimal UsdToAznRate = 1.7m;
        private const decimal AznToUsdRate = 1 / UsdToAznRate;

        public void view(Person onePerson)
        {
            Console.WriteLine($"Xoş gəldiniz, {onePerson.Name} {onePerson.Surname}!");
            Console.WriteLine($"Login: {onePerson.Login}");
            Console.WriteLine($"Balans: {onePerson.Balance}");
            Console.WriteLine($"Valyuta: {onePerson.Currency}");
            Console.WriteLine("Əgər çıxarış etmək istəsəniz 1 daxil edin, ya da sadəcə entere basın");

            string input = Console.ReadLine();
            if (input == "1")
            {
                while (!Withdraw(onePerson))
                {
                    Console.WriteLine($"Balans: {Math.Round(onePerson.Balance, 2)}");
                }
            }
        }

        private bool Withdraw(Person onePerson)
        {
            Console.WriteLine("Çıxarış məbləğini daxil edin:");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Çıxarış valyutasını daxil edin (azn/usd):");
                string withdrawCurrency = Console.ReadLine().ToLower();

                if (withdrawCurrency != "azn" && withdrawCurrency != "usd")
                {
                    Console.WriteLine("Düzgün valyuta daxil edin.");
                    return false;
                }

                if (onePerson.Currency != withdrawCurrency)
                {
                    amount = ConvertCurrency(amount, withdrawCurrency, onePerson.Currency);
                }

                if (onePerson.Withdraw(amount))
                {
                    Console.WriteLine($"Çıxarış uğurlu oldu. Yeni balansınız: {onePerson.Balance}");
                    Console.WriteLine("Əməliyyatı bitirmək üçün 'end' yazın ya da entere basın ki yeni çıxarış edəsiniz");
                    string input = Console.ReadLine();
                    if (input == "end")
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    Console.WriteLine("Balans yetərli deyil.");
                }
            }
            else
            {
                Console.WriteLine("Düzgün məbləğ daxil edin.");
            }

            return false;
        }

        private decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            if (fromCurrency == "usd" && toCurrency == "azn")
            {
                return amount * UsdToAznRate;
            }
            else if (fromCurrency == "azn" && toCurrency == "usd")
            {
                return amount * AznToUsdRate;
            }
            else
            {
                return amount; 
            }
        }
    }
}
