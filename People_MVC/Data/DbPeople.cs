using Microsoft.EntityFrameworkCore;
using People_MVC.Models;
using People_MVC.Data;
using People_MVC.Models.ViewModel;
using People_MVC.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Data
{
    public class DbPeople : IPeopleRepo
    {
        private readonly PeopleDbContext _dbPeopleC;
        private readonly ICityRepo _cityRepo;
        private readonly ILanguageRepo _languageRepo;
        private readonly IPersonLanguageRepo _personLanguageRepo;

        public DbPeople(PeopleDbContext peopleDbContext, ICityRepo cityRepo, ILanguageRepo languageRepo, IPersonLanguageRepo personLanguageRepo)
        {
            _dbPeopleC = peopleDbContext;
            _cityRepo = cityRepo;
            _languageRepo = languageRepo;
            _personLanguageRepo = personLanguageRepo;
        }

        public PersonLanguage AddToPerson(int languageID, int personID)
        {
            throw new NotImplementedException();
        }

     

        public Person Create(CreatePersonViewModel person)  //?Person person
        {
            City selectedCity = _cityRepo.Read(Convert.ToInt32(person.City));

            Person newPerson = new Person();
            newPerson.Name = person.Name;
            newPerson.City = selectedCity;
            newPerson.TeleNumber = person.TeleNumber;

            _dbPeopleC.Persons.Add(newPerson);
            _dbPeopleC.SaveChanges();

            for (int i = 0; i < person.Languages.Length; i++)
            {
                Language selectLanguage = _languageRepo.Read(person.Languages[i]);
                _personLanguageRepo.Create(newPerson, selectLanguage);
            }

            return newPerson;
        }

        public bool Delete(Person person)
        {
            if (person == null)
            {
                 return false;
            }
            else
            {
               var deletePerson = _dbPeopleC.Persons.Where(x => x.PersonId == person.PersonId).FirstOrDefault();
                if (deletePerson == null)
                {
                     return false;
                }
                else
                {
                   _dbPeopleC.Persons.Remove(deletePerson);
                    _dbPeopleC.SaveChanges();
                    return true;
                }
            }
        }

        public List<Person> Read()
        {
            return _dbPeopleC.Persons.Include(people => people.City).AsParallel().ToList();
        }

        public Person Read(int id)
        {
            return _dbPeopleC.Persons.Include(people => people.City).FirstOrDefault(person => person.PersonId == id);
        }

        public Person Update(Person person)
        {
            var updatePerson = _dbPeopleC.Persons.FirstOrDefault(p => p.PersonId == person.PersonId);
            if (updatePerson != null)
            {
                _dbPeopleC.Entry(updatePerson).CurrentValues.SetValues(person);
            }
            return person;
        }

        public string GetCountryName(int personId)
        {
            var query = from a in _dbPeopleC.Persons
                        join b in _dbPeopleC.Cities on a.CityId equals b.CityId
                        join c in _dbPeopleC.Countries on b.CountryId equals c.CountryId
                        where a.PersonId==personId
                        select c.Name;
            string CountryName = query.ToString();
            return CountryName;
        }
    }
}
