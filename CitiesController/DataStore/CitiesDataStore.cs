using CitiesController.Models;
using System.Collections.Generic;

namespace CitiesController.DataStore
{
    public class CitiesDataStore
    {
        private static CitiesDataStore _citiesDataStore;

        public List<City> Cities { get; }
        private CitiesDataStore()
        {
            Cities = new List<City> 
            {
                new City
                {
                    Id = 1,
                    Name = "Moscow",
                    Description = "It is the capital of Russia"
                },
                 new City
                {
                    Id = 2,
                    Name = "Sochi",
                    Description = "It's hot in here"
                }
            };
        }

        public static CitiesDataStore GetInstance()
        {
            if (_citiesDataStore == null)
            {
                _citiesDataStore = new CitiesDataStore();
            }
            return _citiesDataStore;
        }
    }
}
