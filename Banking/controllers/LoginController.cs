using Banking.models;
using Banking.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.controllers
{
    internal class LoginController
    {

        public void index()
        {

            Login loginView = new Login();
            PersonPageController personPageController = new PersonPageController();
            loginView.view();
            Dictionary<string, string> userDetails = loginView.sendToController();
            var allUsers = Person.Persons;
            string login = userDetails["Login"];
            string password = userDetails["Password"];
            while(!logIn(allUsers, login, password, personPageController)) {
                loginView.view();
                userDetails = loginView.sendToController();
                login = userDetails["Login"];
                password = userDetails["Password"];
            }
        }


        public Boolean logIn(List<Person> allUsers, string login, string password, PersonPageController personPageController)
        {
            foreach (Person OnePerson in allUsers)
            {
                if (OnePerson.Login == login && OnePerson.Password == password)
                {
                    personPageController.index(OnePerson);
                    return true;
                }
            }

            Console.WriteLine("Login və ya şifrə yanlışdır.");
            return false;
        }

      

    }
}
