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
    public class DbCountry:ICountryRepo
    {
        private readonly PeopleDbContext _dbPeopleC;

        public DbCountry(PeopleDbContext PeopleDbContext)
        {
            _dbPeopleC = PeopleDbContext;
        }

        public Country Create(CreateCountryViewModel country)
        {
            Country newCountry = new Country { Name = country.Name };

            _dbPeopleC.Countries.Add(newCountry);
            _dbPeopleC.SaveChanges();

            return newCountry;
        }

        public List<Country> Read()
        {
            return _dbPeopleC.Countries.Include(c => c.Cities).ToList();
        }

        public Country Read(int id)
        {
            Country readCountry = (from country in _dbPeopleC.Countries select country) .FirstOrDefault(country => country.CountryId == id);

            return readCountry;
        }

        public Country Update(Country country)
        {
            var query = from updateCountry in _dbPeopleC.Countries where updateCountry.CountryId == country.CountryId select updateCountry;

            foreach (Country data in query)
            {
                data.Name = country.Name;
            }

            _dbPeopleC.SaveChanges();

            return country;
        } 
        
        public bool Delete(Country Country)
        {
            if (Country == null)
            {
                return false;
            }
            else
            {
                var deleteCountry = _dbPeopleC.Countries.Where(x => x.CountryId == Country.CountryId).FirstOrDefault();
                if (deleteCountry == null)
                {
                     return false;
                }
                else
                {
                   _dbPeopleC.Countries.Remove(deleteCountry);
                    _dbPeopleC.SaveChanges();
                    return true;
                }
            }
        }
    }
}
