using System;
using System.Linq;

namespace Homework3
{
    class AllQueries
    {
        private string _connectionString;

        public AllQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IQueryable GetAllContinents()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Continents.OrderBy(c => c.Id).Select(c => new { c.Id, c.ContinentName });

            return query;
        }


        public IQueryable<Continent> GetContinentsByTypeSpecifically()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            IQueryable<Continent> query = db.Continents.OrderBy(c => c.Id);

            return query;
        }

        public IQueryable GetAllCountries()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Countries.OrderBy(c => c.Id).Select(c => new { c.Id, c.CountryName, c.Continent.ContinentName, c.Area });

            return query;
        }


        public IQueryable GetCountryByContinent(string continentName)
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Countries.Where(c => c.Continent.ContinentName.Equals(continentName)).OrderBy(c => c.Id).Select(c => new { c.Id, c.CountryName, c.Area });

            return query;
        }


        public IQueryable<Country> GetCountriesByTypeSpecifically()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            IQueryable<Country> query = db.Countries.OrderBy(c => c.Id);

            return query;
        }

        public IQueryable GetAllCities()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Cities.OrderBy(c => c.Id).Select(c => new { c.Id, c.CityName, c.Country.CountryName, c.PopulationNumber, c.IsCapital });

            return query;
        }


        public IQueryable GetCityByCountry(string countryName)
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Cities.Where(c => c.Country.CountryName.Equals(countryName)).OrderBy(c => c.Id).Select(c => new { c.Id, c.CityName, c.PopulationNumber, c.IsCapital });

            return query;
        }


        public IQueryable GetAllCapitals()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Cities
                    .Where(c => c.IsCapital == Convert.ToBoolean(1))
                    .OrderBy(c => c.Id)
                    .Select(c => new { c.Id, c.CityName, c.Country.CountryName, c.PopulationNumber });

            return query;
        }


        public IQueryable GetTop5CountriesByArea()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Countries
                    .OrderByDescending(c => c.Area)
                    .Take(5)
                    .Select(c => new { c.Id, c.CountryName, c.Area });

            return query;
        }


        public IQueryable GetTop5CountriesByPopulation()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Countries
                    .OrderByDescending(c => c.Cities.Sum(s => s.PopulationNumber))
                    .Take(5)
                    .Select(c => new { c.Id, c.CountryName });

            return query;
        }


        public IQueryable GetTop5CitiesByPopulation()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Cities
                    .OrderByDescending(c => c.PopulationNumber)
                    .Take(5)
                    .Select(c => new { c.Id, c.CityName, c.Country.CountryName, c.PopulationNumber });

            return query;
        }


        public IQueryable GetTop3ContinentsByArea()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Continents
                    .OrderByDescending(c => c.Countries.Sum( s=>s.Area ))
                    .Take(3)
                    .Select(c => new { c.Id, c.ContinentName });

            return query;
        }


        public IQueryable GetTop3ContinentsByPopulation()
        {
            WorldDbDataContext db = new WorldDbDataContext(_connectionString);

            var query = db.Continents
                    .OrderByDescending(c => c.Countries.Sum(s => s.Cities.Sum(p => p.PopulationNumber)))
                    .Take(3)
                    .Select(c => new { c.Id, c.ContinentName });

            return query;
        }


    }
}
