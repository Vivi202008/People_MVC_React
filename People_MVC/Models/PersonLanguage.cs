using System.ComponentModel.DataAnnotations;

namespace People_MVC.Models
{
    public class PersonLanguage
    {
        [Key]
        //public int ID { get; set; }
        //public int PLanguageId { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}