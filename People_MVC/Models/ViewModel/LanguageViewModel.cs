using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.ViewModel
{
    public class LanguageViewModel
    {
        public CreateLanguageViewModel Language { get; set; }

        public List<Language> Languages = new List<Language>();

        public string Search { get; set; }
    }
}
