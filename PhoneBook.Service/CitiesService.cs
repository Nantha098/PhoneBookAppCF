using PhoneBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service
{
    public class CitiesService
    {
        PersonContext personContext;
        public CitiesService()
        {
            personContext = new PersonContext();
            
        }
        public IEnumerable<City> GetCities()
        {
            return personContext.Cities;
        }
        public IEnumerable<City> AddCities()
        {
            return personContext.Cities;
        }
        public IEnumerable<City> UpdateCities()
        {
            return personContext.Cities;
        }
        public IEnumerable<City> DeleteCities()
        {
            return personContext.Cities;
        }
    }
}
