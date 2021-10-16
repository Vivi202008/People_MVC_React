using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using People_MVC.Models;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleMVC.Controllers
{
    [Authorize(Roles="Admin")]
    public class CountriesController : Controller
    {
        private readonly ICountryService _counrryService;
       
        public CountriesController(ICountryService service)
        {
            this._counrryService = service;
        }
        public IActionResult Index()
        {
            return View(_counrryService.All());
        }

        [HttpGet("/countries/{id}")]
        public IActionResult GetCountry(int id)
        {
            try
            {
                Country country = _counrryService.FindBy(id);
                return PartialView("Country", country);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CreateCountry(string countryName)
        {
            _counrryService.Add(countryName);
           
            return RedirectToAction("Index");
        }

        [HttpGet("/countries/del/{id}")]
        public IActionResult DeleteCountry(int id)
        {
            _counrryService.Remove(id);
            return RedirectToAction("Index");
        }



    }
}
