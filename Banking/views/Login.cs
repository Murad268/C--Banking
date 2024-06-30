using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Banking.views
{
   
    internal class Login
    {
        private string login;
        private string password;

        public void view()
        {
            Console.WriteLine("Login");
            login = Console.ReadLine();
            Console.WriteLine("Şifrə");
            password = Console.ReadLine();
        }

        public Dictionary<string, string> sendToController()
        {
            var userDetails = new Dictionary<string, string>
            {
                { "Login", login },
                { "Password", password }
            };
            return userDetails;
        }
    }
}
