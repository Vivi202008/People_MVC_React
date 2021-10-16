using People_MVC.Data;
using People_MVC.Models.Repo;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace People_MVC.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo ;
        PeopleDbContext _peopleDb;
        //InMemoryPeopleRepo PeopleData = new InMemoryPeopleRepo();
        public static List<Person> _peopleList = new List<Person>();

        //Constructor Injection--Fetching IPeopleRepo Object from Startup ConfigureServices

        public PeopleService(IPeopleRepo peopleRepo, PeopleDbContext peopleDb)
        {
            _peopleRepo = peopleRepo;
            _peopleDb = peopleDb;
        }

        public PeopleService()
        {
            this._peopleDb = new PeopleDbContext();
        }

        public Person Add(CreatePersonViewModel person)
        {
            CreatePersonViewModel addPerson = new CreatePersonViewModel
            {
                //ID = _peopleList.Count+1,
                City = person.City,
                Name = person.Name,
                TeleNumber =person.TeleNumber
            };
            return _peopleRepo.Create(addPerson);
        }

        public PeopleViewModel All()
        {

            PeopleViewModel indexViewModel = new PeopleViewModel
            {
                people = _peopleDb.Persons.ToList()
            };
            return indexViewModel;
        }

         public Person FindBy(int id)
        {
            return _peopleRepo.Read(id);
        }



        public bool Remove(int id)
        {
            Person person = FindBy(id);
            return _peopleRepo.Delete(person);
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            search.people = _peopleList.FindAll(
                person => person.Name.Contains(search.Search,StringComparison.OrdinalIgnoreCase)
                       || person.City.Name.Contains(search.Search, StringComparison.OrdinalIgnoreCase)
                       || person.TeleNumber.Contains(search.Search)
            );

            return search;
        }

        public PersonLanguage AddToPerson(int LanguageID, int PersonID)
        {
            return _peopleRepo.AddToPerson(LanguageID, PersonID);
        }

        public string GetCountryName(int cityId)
        {
            var query = from a in _peopleDb.Persons
                        join b in _peopleDb.Cities on a.CityId equals b.CityId
                        join c in _peopleDb.Countries on b.CountryId equals c.CountryId
                        where a.CityId==cityId
                        select c.Name;

            return query.ToString();
        }

        public string GetPersonLanguage(int personId)
        {
            var query = from a in _peopleDb.Persons
                        join d in _peopleDb.PersonLanguages on a.PersonId equals d.PersonId
                        join e in _peopleDb.Languages on d.LanguageId equals e.LanguageId
                        where a.PersonId == personId
                        select new { PLanguage = d.Language.Name };
            string PLanguages = "";
            foreach(var item in query.ToList())
            {
                PLanguages = PLanguages + "  " + item.PLanguage;
            }
            return PLanguages;
        }
    }
}
