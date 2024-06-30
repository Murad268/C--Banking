using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.models
{
    internal class Person
    {
        public static List<Person> Persons = new List<Person>();

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public string Password { get; set; }

        public Person()
        {
            Persons.Add(this);
        }

        public static List<Person> GetAllUsers()
        {
            return Persons;
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
