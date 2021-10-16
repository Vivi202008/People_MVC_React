using People_MVC.Models.Repo;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Service
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepo _languageRepo;
        public LanguageService(ILanguageRepo languageRepo)
        {
            _languageRepo = languageRepo;
        }

        public Language Add(string language)
        {
            return _languageRepo.Create(language);
        }

        public LanguageViewModel All()
        {
            LanguageViewModel languageVM = new LanguageViewModel
            {
                Languages = _languageRepo.Read()
            };

            return languageVM;
        }

        public Language FindBy(int id)
        {
            return _languageRepo.Read(id);
        }

        public Language FindBy(string search)
        {
            return _languageRepo.FindBy(search);
        }

        public LanguageViewModel FindBy(LanguageViewModel search)
        {
            search.Languages = _languageRepo.Read().FindAll(language => language.Name.Contains(search.Search, StringComparison.OrdinalIgnoreCase));
            return search;
        }

        public bool Remove(int id)
        {
            Language language = FindBy(id);
            return _languageRepo.Delete(language);
        } 
        
        public PersonLanguage AddToPerson(int LanguageID,int PersonID)
        {
            return _languageRepo.AddToPerson(LanguageID, PersonID);
        }
    }
}
