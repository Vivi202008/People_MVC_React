using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Repo
{
    public interface ILanguageRepo
    {
        public Language Create(string language);

        public Language Read(int id);
        public List<Language> Read(PersonLanguage personLanguage);
        public Language FindBy(string search);

        public bool Delete(Language language);
        public Language Update(Language language);
        List<Language> Read();
        PersonLanguage AddToPerson(int languageID, int personID);
    }
}
