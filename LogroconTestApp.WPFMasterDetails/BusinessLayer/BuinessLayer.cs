using System.Collections.Generic;
using DataAccess;
using DomainModel;

namespace BusinessLayer
{
    public class BuinessLayer : IBusinessLayer
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IStreetsRepository _streetsRepository;
 
        public BuinessLayer()
        {
            _citiesRepository = new CitiesRepository();
            _streetsRepository = new StreetsRepository();
        }
 
        public BuinessLayer(ICitiesRepository deptRepository,
            IStreetsRepository streetsRepository)
        {
            _citiesRepository = deptRepository;
            _streetsRepository = streetsRepository;
        }
 
        public IList<Cities> GetAllCities()
        {
            return _citiesRepository.GetAll();
        }
 
        public Cities GetCitiesByName(string citiesName)
        {
            return _citiesRepository.Get(
                x => x.Name.Equals(citiesName), 
                x => x.Streets);
        }
 
        public void AddCities(params Cities[] cities)
        {
            if(ValidationCities(cities) == false)
                return;
            _citiesRepository.InsertMany(cities);
        }

        private bool ValidationCities(Cities[] cities)
        {
            foreach (var city in cities)
            {
                if (city.Name == null || city.Region == null)
                    return false;
            }
            return true;
        }

        public void UpdateCities(params Cities[] cities)
        {
            if (ValidationCities(cities) == false)
                return;
            _citiesRepository.Update(cities);
        }
 
        public void RemoveCities(params Cities[] cities)
        {
            /* Validation and error handling omitted */
            _citiesRepository.Delete(cities);
        }
 
        public IList<Streets> GetStreetssByCitiesName(string citiesName)
        {
            return _streetsRepository.GetList(x => x.Cities.Name.Equals(citiesName));
        }

        public IList<Streets> GetStreetssByCitiesNumber(int citiesNumber)
        {
            return _streetsRepository.GetList(x => x.CityNumber.Equals(citiesNumber));
        }

        public void AddStreet(Streets streets)
        {
            if (ValidationStreets(streets) == false)
                return;
            _streetsRepository.InsertMany(streets);
        }

        private bool ValidationStreets(Streets streets)
        {
            if (streets.Name == null)
                return false;
            return true;
        }

        public void UpdateStreet(Streets streets)
        {
            if (ValidationStreets(streets) == false)
                return;
            _streetsRepository.Update(streets);
        }
 
        public void RemoveStreet(Streets streets)
        {
            /* Validation and error handling omitted */
            _streetsRepository.Delete(streets);
        }
    }
}