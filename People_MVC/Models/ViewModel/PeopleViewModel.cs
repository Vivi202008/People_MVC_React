using People_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace People_MVC.Models.ViewModel
{
    public class PeopleViewModel
    {
        [Required(ErrorMessage = "Fill out anything to search !")]
        [RegularExpression(@"[A-zåäöÅÄÖ][0-9]*", ErrorMessage = "Use only alphabets or numbers.")]
        [MaxLength(30),MinLength(2)]
        public string Search { get; set; }

        public CreatePersonViewModel Person { get; set; }
        public List<Person> people = new List<Person>();

        //public List<City> Cities { get; set; } = new List<City>();
        ////// public List<Country> Countries { get; set; } = new List<Country>();
        // public List<Language> Languages { get; set; } = new List<Language>();
        //public List<PersonLanguage> PersonLanguages { get; set; } = new List<PersonLanguage>();
    }
}
