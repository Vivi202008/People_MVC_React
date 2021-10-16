using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People_MVC.Models.ViewModel;

namespace People_MVC.Models.Repo
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> _peopleList = new List<Person>();
        public static List<Person> allPeopleList = _peopleList;
        
        private static int idCounter = _peopleList.Count();
        
        public int IdCounter
        { 
            get {
                return idCounter;
            }
          private set {
                idCounter++;
            }
        }


        public static void CreateDefaultPeoples()
        {
            //_peopleList.Add(new Person() { ID = 1, City ="Beijing", Name="Helena", TeleNumber="1112345677"});
            //_peopleList.Add(new Person() { ID = 2, City = "Göteborg", Name = "Erik", TeleNumber = "22234678236" });
            //_peopleList.Add(new Person() { ID = 3, City = "Paris", Name = "Johan", TeleNumber = "33334567890" });
            //_peopleList.Add(new Person() { ID = 4, City = "Beijing", Name = "Hua", TeleNumber = "88888888888" });
            //_peopleList.Add(new Person() { ID = 5, City = "Paris", Name = "Linda", TeleNumber = "23333333343" });
            idCounter = _peopleList.Count();
        }
        
        public Person Create(CreatePersonViewModel person)
        {
            idCounter++;
            Person addPerson = new Person();
            addPerson.PersonId = IdCounter;
            addPerson.Name = person.Name;
            addPerson.City = new City { Name = person.City };
            addPerson.TeleNumber = person.TeleNumber;

            _peopleList.Add(addPerson);

            return addPerson;            
        }

        public bool Delete(Person person)
        {
            return _peopleList.Remove(person);
        }

        public Person Read(int id)
        {
            return _peopleList.FirstOrDefault(p => p.PersonId == id);
        }

        public List<Person> Read()
        {
            return _peopleList;
        }

        public Person Update(Person person)
        {
            int index = _peopleList.FindIndex(p => p.PersonId == person.PersonId);
            if (index == -1)
            {
                 throw new ArgumentNullException();
            }
            else
            {
                _peopleList[index] = person;
                return _peopleList[index];               
            }
        }

        public PersonLanguage AddToPerson(int languageID, int personID)
        {
            throw new NotImplementedException();
        }
    }
}
