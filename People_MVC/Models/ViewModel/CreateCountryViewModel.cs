using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.ViewModel
{
    public class CreateCountryViewModel
    {
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Fill out Country's name!")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }
        public List<City> Cities { get; set; }

        //public int CityId { get; set; }
        //public Country Country { get; set; }
    }
}
