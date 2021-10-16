using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Service
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel search);
             
        Person FindBy(int id);
        bool Remove(int id);

        //Person Edit(int id, Person person);
        PersonLanguage AddToPerson(int LanguageID, int PersonID);

        string GetCountryName(int cityId);
        string GetPersonLanguage(int personId);
    }
}
