using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Repo
{
    public interface ICityRepo
    {
        //public City Create(CreateCityViewModel city);

        public City Create(string cityName, string countryName);

        public List<City> Read();
        public City Read(int id);

        public City Update(City city);
        public bool Delete(City city);
    }
}
