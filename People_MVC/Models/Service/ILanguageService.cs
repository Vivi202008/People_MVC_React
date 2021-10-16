using People_MVC.Models.ViewModel;
using People_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People_MVC.Models.Service
{
    public interface ILanguageService
    {
        Language Add(string language);

        LanguageViewModel All();

        Language FindBy(int id);
        Language FindBy(string search);
        LanguageViewModel FindBy(LanguageViewModel search);

        bool Remove(int id);
    }
}

    
