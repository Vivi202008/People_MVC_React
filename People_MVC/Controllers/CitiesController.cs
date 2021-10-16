using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using People_MVC.Models;
using People_MVC.Models.Service;
using People_MVC.Models.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleMVC.Controllers
{      
    [Authorize(Roles = "Admin")]
    public class CitiesController : Controller
    {
        private readonly ICityService _service;
        private readonly ICountryService _countryService;

        public CitiesController(ICityService service, ICountryService countryService)
        {
            this._service = service;
            this._countryService = countryService;
        }
        public IActionResult Index()
        {
            ViewBag.Countries = new SelectList(_countryService.All().Countries, "Id", "Name");

            return View(_service.All());
        }

        [HttpGet("cities/{id}")]
        public IActionResult GetCity(int id)
        {
            try
            {
                City city = _service.FindBy(id);
                return PartialView("City", city);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult CreateCity(string cityName, string countryName)
        {
            if (ModelState.IsValid)
            {
                _service.Create(cityName,countryName);

            }

            return RedirectToAction("Index");
        }

        [HttpGet("cities/del/{id}")]
        public IActionResult DeleteCity(int id)
        {
            _service.Remove(id);
            return RedirectToAction("Index");
        }

  
    }
}
