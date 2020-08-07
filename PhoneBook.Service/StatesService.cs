using PhoneBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service
{
   public class StatesService
    {
        PersonContext personContext;
        public StatesService()
        {
            personContext = new PersonContext();

        }
        public IEnumerable<State> GetStates()
        {
            return personContext.States;
        }
        public IEnumerable<State> AddStates()
        {
            return personContext.States;
        }
        public IEnumerable<State> UpdateStates()
        {
            return personContext.States;
        }
        public IEnumerable<State> DeleteStates()
        {
            return personContext.States;
        }
    }
}
