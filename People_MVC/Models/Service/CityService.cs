using People_MVC.Models.Repo;
using People_MVC.Data;
using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace People_MVC.Models.Service
{
    public class CityService : ICityService
    {
        public ICityRepo _cityRepo;
        PeopleDbContext _dbPeopleC;

        public CityService(ICityRepo cityRepo, PeopleDbContext dbPeopleC)
        {
            _cityRepo = cityRepo;
            _dbPeopleC = dbPeopleC;
        }

        public City Add(string cityName,string countryName)
        {
            //CreateCityViewModel newCity = new CreateCityViewModel
            //{
            //    Name = cityName,
            //    CountryId = _cityRepo.Read().Last().CountryId + 1
            //};
            return _cityRepo.Create(cityName,countryName); ;
        }

        public CityViewModel All()
        {
            CityViewModel cityViewModel = new CityViewModel
            {
                Cities = _cityRepo.Read()
            };
            return cityViewModel;
        }

        public City Create(string cityName, string countryName)
        {
            var query1 = _dbPeopleC.Countries.Include(m => countryName);
            int newCountryId=0;

            try
            {
                newCountryId = query1.ToList()[1].CountryId;
            }
            catch
            {
                newCountryId = _dbPeopleC.Countries.LastOrDefault().CountryId + 1;          
                Country newCountry = new Country { Name = countryName, CountryId = newCountryId };
                _dbPeopleC.Countries.Add(newCountry);
            }
                   
            City newCity = new City { Name = cityName, CountryId = newCountryId };

            _dbPeopleC.Cities.Add(newCity);

            _dbPeopleC.SaveChanges();

            return newCity;
        }

        public City FindBy(int id)
        {
            return _cityRepo.Read(id);
        }

        public CityViewModel FindBy(CityViewModel search)
        {
            search.Cities = _cityRepo.Read().FindAll(city => city.Name.Contains(search.Search, StringComparison.OrdinalIgnoreCase));
            return search;
        }

        public bool Remove(int id)
        {
            City city = FindBy(id);
            return _cityRepo.Delete(city);
        }
    }
}
