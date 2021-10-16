using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using People_MVC.Models;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;

namespace People_MVC.Controllers
{
    [AllowAnonymous]
    public class PeopleCMSController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICountryService _countryService;
        private readonly ILanguageService _languageService;

        public PeopleCMSController(IPeopleService peopleService, ILanguageService languageService, ICountryService countryService)
        {
            _peopleService = peopleService;
            _countryService = countryService;
            _languageService = languageService;
        }

        [HttpGet("[controller]")]
        public IActionResult GetMainPage()
        {
            return File("/PeopleCMS/index.html", "text/html");
        }

        [HttpGet("[controller]/people")]
        public ActionResult<PeopleViewModel> GetAllPeople()
        {
            return new JsonResult(_peopleService.All());
        }

        [HttpGet("[controller]/languages")]
        public ActionResult<LanguageViewModel> GetAllLanguages()
        {
            return new JsonResult(_languageService.All());
        }

        [HttpGet("[controller]/countries")]
        public ActionResult<CountryViewModel> GetAllCountries()
        {
            return new JsonResult(_countryService.All());
        }

        [HttpGet("[controller]/people/{id}")]
        public ActionResult<PeopleViewModel> GetOne(int id)
        {
            try
            {
                return new JsonResult(_peopleService.FindBy(id));
            }
            catch (Exception)
            {
                return new NotFoundResult();
            }
        }

        [HttpPost("[controller]/people")]
        public ActionResult<PeopleViewModel> AddPerson([FromBody] CreatePersonViewModel person)
        {

            if (ModelState.IsValid)
            {
                Person createdPerson = _peopleService.Add(person);
                return new JsonResult(createdPerson);
            }

            return new BadRequestResult();
        }

        [HttpDelete("[controller]/people/{id}")]
        public IActionResult RemovePerson(int id)
        {
            if (_peopleService.Remove(id))
            {
                return new OkResult();
            }

            return new NotFoundResult();
        }
    }
}

