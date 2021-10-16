using People_MVC.Models.Repo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models
{
    public class CreatePersonViewModel
    {
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [RegularExpression(@"[A-zåäöÅÖÄ]*", ErrorMessage = "Use only alphabets!")]
        public string City { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public int[] Languages { get; set; }

        //[Required]
        //[StringLength(30, MinimumLength = 2)]
        //[RegularExpression(@"[A-zåäöÅÖÄ]*", ErrorMessage = "Use only alphabets!")]
        //public string Country { get; set; }

        [Required(ErrorMessage = "Fill out name field!")]
        [StringLength(50,MinimumLength =2)]
        public string Name{ get; set; }

        [Required]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "Please input only numbers. ")]
        [StringLength(20, MinimumLength = 8)]
        public string TeleNumber { get; set; }

        //[Required]
        //public int ID
        //{
        //    get
        //    {
        //        return ID;
        //    }
        //    set
        //    {
        //        ID = value;
        //    }
        //}
    }
}
