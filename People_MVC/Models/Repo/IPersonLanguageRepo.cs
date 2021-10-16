using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace People_MVC.Models.Repo
{
    public interface IPersonLanguageRepo
    {
        public PersonLanguage Create(Person person, Language language);

        public PersonLanguage Read(int id);
        public List<PersonLanguage> Read();

        public List<PersonLanguage> Update(int[] languages, Person person);
        public bool Delete(PersonLanguage personLanguage);
    }
}
