using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public List<PersonLanguage> PersonLanguages { get; set; }  //many to many
    }
}

