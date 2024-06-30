using Banking.models;
using Banking.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.controllers
{
    internal class PersonPageController
    {
        public void index(Person OnePerson)
        {
            PersonPage personPage = new PersonPage();
            personPage.view(OnePerson);
        }
    }
}
