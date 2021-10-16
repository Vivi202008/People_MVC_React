using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using People_MVC.Models;

namespace People_MVC.Models.ViewModel
{
    public class CreateCityViewModel
    {
        public int CityId { get; set; }

        [Required(ErrorMessage = "Fill out city's name!")]
        [RegularExpression(@"[A-zåöä]*", ErrorMessage = "Use only alphabets.")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        public List<Person> People { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
