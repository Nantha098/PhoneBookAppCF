using PhoneBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service
{
    public class PeopleService
    {
        PersonContext personContext;
        public PeopleService()
        {
            personContext = new PersonContext();

        }
        public IEnumerable<Person> GetPeople()
        {
            return personContext.People;
        }
        public IEnumerable<Person> AddPeople()
        {
            return personContext.People;
        }
        public IEnumerable<Person> UpdatePeople()
        {
            return personContext.People;
        }
        public IEnumerable<Person> DeletePeople()
        {
            return personContext.People;
        }
    }
}
