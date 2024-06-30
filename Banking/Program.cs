using Banking.controllers;
using Banking.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            bool endTask = true;
            RegisterController registerController = new RegisterController();
            LoginController loginController = new LoginController();
            while (endTask)
            {
                Console.WriteLine("Qeydiyyatdan keçmək istəyirsinizsə 1, daxil olmaq istəyirsinizsə 2, bütün istifadəçiləri görmək istəyirsinizsə 3 seçin:");
                string input = Console.ReadLine();
                int checking;

                try
                {
                    checking = Convert.ToInt32(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Düzgün rəqəm daxil edin.");
                    continue;
                }

                switch (checking)
                {
                    case 1:
                        registerController.index();
                        break;
                    case 2:
                        loginController.index();
                        break;
                    case 3:
                        List<Person> allUsers = Person.GetAllUsers();
                        Console.WriteLine("Bütün istifadəçilər:");
                        foreach (var user in allUsers)
                        {
                            Console.WriteLine($"Ad: {user.Name}, Soyad: {user.Surname}, Login: {user.Login}, Balans: {user.Balance}, Valyuta: {user.Currency}");
                        }
                        break;
                    default:
                        Console.WriteLine("Düzgün seçim edin.");
                        break;
                }
            }
        }
    }
}
