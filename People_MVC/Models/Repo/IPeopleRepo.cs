using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Repo
{
    public interface IPeopleRepo
    {
       // get all
       public Person Create(CreatePersonViewModel person);
        public List<Person> Read();
        public Person Read(int id);

        public Person Update(Person person);
        public bool Delete(Person person);
        PersonLanguage AddToPerson(int languageID, int personID);
    }
}
