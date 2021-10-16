using Microsoft.EntityFrameworkCore;
using People_MVC.Models;
using People_MVC.Models.Repo;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Data
{
    public class DbLanguage : ILanguageRepo
    {
        private readonly PeopleDbContext _dbPeopleC;

        public DbLanguage(PeopleDbContext PeopleDbContext)
        {
            _dbPeopleC = PeopleDbContext;
        }

        public Language Create(string language)
        {
            Language newLanguage = new Language();
            newLanguage.Name = language;

            _dbPeopleC.Languages.Add(newLanguage);
            _dbPeopleC.SaveChanges();

            return newLanguage;
        }

        public List<Language> Read()
        {
            var query = (from language in _dbPeopleC.Languages select language).Include(c => c.PersonLanguages);

            return query.ToList();
        }

        public Language Read(int id)
        {
            Language readLanguage = (from language in _dbPeopleC.Languages select language).Include(c => c.PersonLanguages).FirstOrDefault(language => language.LanguageId == id);

            return readLanguage;
        }

        public Language Update(Language language)
        {
            var query = from updateLanguage in _dbPeopleC.Languages where updateLanguage.LanguageId == language.LanguageId select updateLanguage;

            foreach (Language data in query)
            {
                data.Name = language.Name;
            }

            _dbPeopleC.SaveChanges();

            return language;
        }

        public bool Delete(Language language)
        {
            if (language == null)
            {
                return false;
            }
            else
            {
                var deleteLanguage = _dbPeopleC.Languages.Where(x => x.LanguageId == language.LanguageId).FirstOrDefault();
                if (deleteLanguage == null)
                {
                    return false;
                }
                else
                {
                    _dbPeopleC.Languages.Remove(deleteLanguage);
                    _dbPeopleC.SaveChanges();
                    return true;
                }
            }
        }

        public List<Language> Read(PersonLanguage personLanguage)
        {
            var query = (from language in _dbPeopleC.Languages select language)
                        .Include(c => c.PersonLanguages);

            return query.ToList();
        }

        public Language FindBy(string search)
        {
            var serchLanguage = (from language in _dbPeopleC.Languages
                                   select language)
                         .FirstOrDefault();
            return serchLanguage;
        }

        public PersonLanguage AddToPerson(int languageID, int personID)
        {
            PersonLanguage personL = new PersonLanguage();
            personL.LanguageId = languageID;
            personL.PersonId = personID;
            _dbPeopleC.PersonLanguages.Add(personL);
            _dbPeopleC.SaveChanges();
            return personL;
        }
    }
}
