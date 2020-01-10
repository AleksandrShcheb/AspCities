using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CitiesController.DataStore;
using CitiesController.Models;

namespace CitiesController.Controllers
{
    public class CitiesController : Controller
    {
        [HttpGet("/api/cities")]
        public IActionResult GetCities()
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            var cities = citiesDataStore.Cities;

            return Ok(cities);

        }
        [HttpGet("/api/cities/{id}")]
        public IActionResult GetCity(int id)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            foreach (var city in citiesDataStore.Cities)
            {
                if (city.Id == id)
                {
                    return Ok(city);
                }
            }

            return NotFound();
        }
        [HttpPost("/api/cities/")]
        public IActionResult AddCity([FromBody] City city)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            citiesDataStore.Cities.Add(city);

            return Created("/api/cities/" + city.Id, city);
        }


        [HttpDelete("/api/cities/{id}")]
        public IActionResult DeleteCity(int id)
        {
            var citiesDataStore = CitiesDataStore.GetInstance();
            foreach (var city in citiesDataStore.Cities)
            {
                if (city.Id == id)
                {
                    citiesDataStore.Cities.Remove(city);
                    return NotFound();
                }
            }
            return Ok(citiesDataStore.Cities);
        }
    }
}











