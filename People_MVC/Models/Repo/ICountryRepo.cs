using People_MVC.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Repo
{
    public interface ICountryRepo
    {
        public Country Create(CreateCountryViewModel country);
       
        public List<Country> Read();
        public Country Read(int id);

        public Country Update(Country country);

        public bool Delete(Country country);
    }
}
