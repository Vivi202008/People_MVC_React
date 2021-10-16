using People_MVC.Models;
using People_MVC.Models.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Data
{
    public class DbPersonLanguage : IPersonLanguageRepo
    {
        private readonly PeopleDbContext _dbPeopleC;
        private readonly ILanguageRepo _languageRepo;

        public DbPersonLanguage(PeopleDbContext peopleDbContext, ILanguageRepo languageRepo)
        {
            _dbPeopleC = peopleDbContext;
            _languageRepo = languageRepo;
        }

        public PersonLanguage Create(Person person, Language language)
        {
            PersonLanguage newPersonLanguage = new PersonLanguage
            {
                Person = person,
                Language = language
            };
            _dbPeopleC.PersonLanguages.Add(newPersonLanguage);
            _dbPeopleC.SaveChanges();

            return newPersonLanguage;
        }

        public bool Delete(PersonLanguage personLanguage)
        {
            if (personLanguage == null)
            {
                return false;
            }
            else
            {
                var deletePLanguage = _dbPeopleC.PersonLanguages.Where(x => x.LanguageId == personLanguage.LanguageId).FirstOrDefault();
                if (deletePLanguage == null)
                {
                    return false;
                }
                else
                {
                    _dbPeopleC.PersonLanguages.Remove(deletePLanguage);
                    _dbPeopleC.SaveChanges();
                    return true;
                }
            }
        }

        public List<PersonLanguage> Update(int[] languages, Person person)
        {
            for (int i = 0; i < languages.Length; i++)
            {
                Language selectedLanguage = _languageRepo.Read(languages[i]);
                Create(person, selectedLanguage);
                PersonLanguage newPersonLanguage = new PersonLanguage { Language = selectedLanguage, Person = person };
                _dbPeopleC.PersonLanguages.Add(newPersonLanguage);
            }

            _dbPeopleC.SaveChanges();
            return person.PersonLanguages;
        }        
        
        public PersonLanguage Read(int id)
        {
            var query = (from personLanguage in _dbPeopleC.PersonLanguages select personLanguage).FirstOrDefault(x => x.PersonId == id);

            return query;
        }

        public List<PersonLanguage> Read()
        {
            var query = from personLanguage in _dbPeopleC.PersonLanguages select personLanguage;

            return query.ToList();
        }

    }
}
