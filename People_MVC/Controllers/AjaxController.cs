using Microsoft.AspNetCore.Mvc;
using People_MVC.Data;
using People_MVC.Models;
using People_MVC.Models.Repo;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNetCore.Http;


namespace People_MVC.Controllers
{
    public class AjaxController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly IPeopleRepo _peopleRepo;
        readonly PeopleDbContext _context;
        PeopleService peopleService = new PeopleService();

        public static List<Person> _peopleList = new List<Person>();

        public AjaxController(IPeopleService peopleService, IPeopleRepo peopleRepo, PeopleDbContext context)
        {
            
            _peopleService = peopleService;
            _peopleRepo = peopleRepo;
            _context = context;
            
           
        }

       [HttpGet]
        public IActionResult ShowAll()
        {
            return PartialView("_ShowAll", _peopleService.All());
        }

        [HttpGet]
        public IActionResult Show(string searchId)
        {
            PeopleViewModel peopleSearch = new PeopleViewModel
            {
                Search = searchId
            };
            if (string.IsNullOrEmpty(peopleSearch.Search))
            {
                return PartialView("_Show", peopleService.All());
            }
            return PartialView(
                "_Show", peopleService.FindBy(peopleSearch));
        }

        //Get
        public IActionResult Management()
        {
            List<dynamic> oneList = new List<dynamic>();
            foreach (var item in _context.Persons)
            {
                dynamic dyObj = new ExpandoObject();
                dyObj.PId = item.PersonId;
                dyObj.CountryName = peopleService.GetCountryName(item.CityId);
                dyObj.PLanguage = peopleService.GetPersonLanguage(item.PersonId);

                oneList.Add(dyObj);
            }

            ViewBag.data = oneList;
            return View();
        }


        [HttpPost]
        public IActionResult PersonDetails(int ID)
        {      
            return PartialView("_PersonDetails",_peopleRepo.Read(ID));
        }

        [HttpPost]
        public IActionResult Delete(int ID)
        {            
            Person deletePerson = _peopleRepo.Read(ID);
            if (deletePerson!=null)
            {
                ViewBag.Message = $"Person with id {ID} has been deleted";
                return PartialView("_Delete", _peopleRepo.Delete(deletePerson));
            }
            else
            {
                ViewBag.Message = $"person with id {ID} is not exist.";
                return PartialView("_Delete", _peopleRepo.Delete(deletePerson));
            }
            //Person deletePerson = _peopleRepo.Read(ID);
            //return PartialView("_Delete", _peopleRepo.Delete(deletePerson));
        }
    }
}