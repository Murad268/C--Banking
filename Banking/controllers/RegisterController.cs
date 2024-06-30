using Banking.models;
using Banking.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.controllers
{
    internal class RegisterController
    {
        public void index()
        {
            Register registerView = new Register();
            registerView.view();
            Dictionary<string, object> userDetails = registerView.sendToController();

            // Duplicate login check
            while (checkDuplicateLogin((string)userDetails["Login"]))
            {
                Console.WriteLine("Bu login artıq mövcuddur, fərqli bir login təyin edin:");
                registerView.askForLogin();
                userDetails = registerView.sendToController();
            }

            string password = (string)userDetails["Password"];
            string rePassword = (string)userDetails["RePassword"];

            while (!checkPassword(password, rePassword))
            {
                registerView.retryPassword();
                userDetails = registerView.sendToController();
                password = (string)userDetails["Password"];
                rePassword = (string)userDetails["RePassword"];
            }

            Person person = new Person
            {
                Name = (string)userDetails["Name"],
                Surname = (string)userDetails["Surname"],
                Login = (string)userDetails["Login"],
                Balance = (decimal)userDetails["Balance"],
                Currency = (string)userDetails["Currency"],
                Password = (string)userDetails["Password"]
            };

            Console.WriteLine("Qeydiyyat tamamlandı.");
        }

        private bool checkDuplicateLogin(string login)
        {
            foreach (var person in Person.Persons)
            {
                if (person.Login == login)
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkPassword(string password, string rePassword)
        {
            if (password != rePassword)
            {
                Console.WriteLine("Şifrələr eyni deyil, yenidən cəhd edin.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
