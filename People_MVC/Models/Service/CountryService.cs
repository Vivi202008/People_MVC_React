using People_MVC.Models;
using People_MVC.Data;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People_MVC.Models.Repo;

namespace People_MVC.Models.Service
{
    public class CountryService : ICountryService
    {
        ICountryRepo _countryRepo;
        public CountryService (ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public Country Add(string countryName)
        {
            CreateCountryViewModel newCountry = new CreateCountryViewModel
            {
                Name = countryName
            };
            return _countryRepo.Create(newCountry);
        }

        public CountryViewModel All()
        {
            CountryViewModel CountryVM = new CountryViewModel { Countries = _countryRepo.Read() };
            return CountryVM;
        }

        public CountryViewModel FindBy(CountryViewModel search)
        {
            search.Countries = _countryRepo.Read().FindAll(country => country.Name.Contains(search.Search, StringComparison.OrdinalIgnoreCase));

            return search;
        }

        public Country FindBy(int id)
        {
            return _countryRepo.Read(id);
        }

        public bool Remove(int id)
        {
            Country country = FindBy(id);
            return _countryRepo.Delete(country);
        }
    }
}
