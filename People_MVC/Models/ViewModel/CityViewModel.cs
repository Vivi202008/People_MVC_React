using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using People_MVC.Models;

namespace People_MVC.Models.ViewModel
{
    public class CityViewModel
    {
        public CreateCityViewModel City { get; set; }

        public List<City> Cities = new List<City>();

        public string Search { get; set; }
    }
}
