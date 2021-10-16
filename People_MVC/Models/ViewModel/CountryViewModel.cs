using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.ViewModel
{
    public class CountryViewModel
    {
        public CreateCountryViewModel Country { get; set; }
        public List<Country> Countries = new List<Country>();

        public string Search { get; set; }
    }
}
