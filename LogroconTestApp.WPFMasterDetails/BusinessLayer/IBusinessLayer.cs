using System.Collections.Generic;
using DataAccess;
using DomainModel;

namespace BusinessLayer
{
public interface IBusinessLayer
    {
        //я специально сделал единственнное и множественное числа во входных параметрах, что бы убедиться, что работет
        IList<Cities> GetAllCities();
        Cities GetCitiesByName(string citiesName);
        void AddCities(params Cities[] cities);
        void UpdateCities(params Cities[] cities);
        void RemoveCities(params Cities[] cities);
        
        IList<Streets> GetStreetssByCitiesName(string citiesName);
        IList<Streets> GetStreetssByCitiesNumber(int citiesNumber);
        void AddStreet(Streets streets);
        void UpdateStreet(Streets streets);
        void RemoveStreet(Streets streets);
    }
}