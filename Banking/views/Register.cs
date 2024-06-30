using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.views
{
    internal class Register
    {
        private List<string> currencies = new List<string> { "azn", "usd" };
        private string name;
        private string surname;
        private string login;
        private decimal balance;
        private string currency;
        private string password;
        private string repassword;

        public void view()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Adınızı daxil edin:");
            name = Console.ReadLine();
            while (checkEmpty(name))
            {
                Console.WriteLine("Adınızı daxil edin (boş ola bilməz):");
                name = Console.ReadLine();
            }

            Console.WriteLine("Soy adınızı daxil edin:");
            surname = Console.ReadLine();
            while (checkEmpty(surname))
            {
                Console.WriteLine("Soy adınızı daxil edin (boş ola bilməz):");
                surname = Console.ReadLine();
            }

            askForLogin();

            askForBalance();

            askForCurrency();
            askForPassword();
        }

        public void askForLogin()
        {
            Console.WriteLine("Login təyin edin:");
            login = Console.ReadLine();
            while (checkEmpty(login))
            {
                Console.WriteLine("Login təyin edin (boş ola bilməz):");
                login = Console.ReadLine();
            }
        }

        private void askForBalance()
        {
            Console.WriteLine("Balansınızı daxil edin:");
            while (!decimal.TryParse(Console.ReadLine(), out balance))
            {
                Console.WriteLine("Düzgün balans məbləği daxil edin (boş ola bilməz):");
            }
        }

        private void askForCurrency()
        {
            Console.WriteLine("Valyutanı seçin (azn/usd):");
            currency = Console.ReadLine().ToLower();
            while (!checkCurrency(currency))
            {
                Console.WriteLine("Düzgün valyuta daxil edin (azn/usd):");
                currency = Console.ReadLine().ToLower();
            }
        }

        private bool checkCurrency(string currency)
        {
            return currencies.Contains(currency);
        }

        private bool checkEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        private void askForPassword()
        {
            Console.WriteLine("Şifrə təyin edin:");
            password = Console.ReadLine();
            while (checkEmpty(password))
            {
                Console.WriteLine("Şifrə təyin edin (boş ola bilməz):");
                password = Console.ReadLine();
            }

            Console.WriteLine("Şifrəni təkrar edin:");
            repassword = Console.ReadLine();
            while (checkEmpty(repassword))
            {
                Console.WriteLine("Şifrəni təkrar edin (boş ola bilməz):");
                repassword = Console.ReadLine();
            }
        }

        public Dictionary<string, object> sendToController()
        {
            var userDetails = new Dictionary<string, object>
            {
                { "Name", name },
                { "Surname", surname },
                { "Login", login },
                { "Password", password },
                { "RePassword", repassword },
                { "Balance", balance },
                { "Currency", currency }
            };
            return userDetails;
        }

        public void retryPassword()
        {
            askForPassword();
        }
    }
}
