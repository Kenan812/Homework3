using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace Homework3
{
    class TableCreate
    {
        private string _connectionString;
        private SqlConnection _connection;

        // To show that table is created for the first time, to insert new values
        private bool _newContinents = false;
        private bool _newCountries = false;
        private bool _newCities = false;

        public TableCreate(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }


        public void CreateAllTables()
        {
            _connection.Open();

            CreateContinentsTable();
            CreateCountriesTable();
            CreateCitiesTable();

            _connection.Close();

        }


        #region Creating All Tables

        private void CreateContinentsTable()
        {
            string query = @"CREATE TABLE Continents(
	                         Id INT IDENTITY(1,1) PRIMARY KEY,
	                         ContinentName NVARCHAR(100) NOT NULL UNIQUE
                             )";

            if (CheckTableExistance(query)) { MessageBox.Show("Table \"Continents\" already exists", "Table creation not successful", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            SqlCommand command = new SqlCommand(query, _connection);

            command.ExecuteNonQuery();

            MessageBox.Show("Continents table created", "Table creation successful", MessageBoxButton.OK, MessageBoxImage.Information);

            _newContinents = true;
        }


        private void CreateCountriesTable()
        {
            string query = @"CREATE TABLE Countries(
	                         Id INT IDENTITY(1,1) PRIMARY KEY,
	                         CountryName NVARCHAR(150) NOT NULL UNIQUE,
	                         ContinentId INT FOREIGN KEY REFERENCES Continents(Id), 
	                         Area FLOAT NOT NULL
                             )";

            if (CheckTableExistance(query)) { MessageBox.Show("Table \"Countries\" already exists", "Table creation not successful", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            SqlCommand command = new SqlCommand(query, _connection);

            command.ExecuteNonQuery();

            MessageBox.Show("Countries table created", "Table creation successful", MessageBoxButton.OK, MessageBoxImage.Information);

            _newCountries = true;
        }


        private void CreateCitiesTable()
        {
            string query = @"CREATE TABLE Cities(
	                         Id INT IDENTITY(1,1) PRIMARY KEY,
	                         CityName NVARCHAR(150) NOT NULL,
	                         CountryId INT FOREIGN KEY REFERENCES Countries(Id),
	                         PopulationNumber INT DEFAULT 0,
	                         IsCapital BIT DEFAULT 0
                             )";

            if (CheckTableExistance(query)) { MessageBox.Show("Table \"Cities\" already exists", "Table creation not successful", MessageBoxButton.OK, MessageBoxImage.Error); return; }

            SqlCommand command = new SqlCommand(query, _connection);

            command.ExecuteNonQuery();

            MessageBox.Show("Cities table created", "Table creation successful", MessageBoxButton.OK, MessageBoxImage.Information);

            _newCities = true;
        }

        #endregion


        public void InsertAllValues()
        {
            _connection.Open();

            InsertAllContinents();
            InsertAllCountries();
            InsertAllCities();

            _connection.Close();
        }

        #region Inserting Values

        public void InsertContinent(string continentName)
        {
            try
            {
                WorldDbDataContext db = new WorldDbDataContext(_connectionString);

                Continent continent = new Continent();
                continent.ContinentName = continentName;

                db.Continents.InsertOnSubmit(continent);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void InsertAllContinents()
        {
            if (_newContinents)
            {
                InsertContinent("Asia");
                InsertContinent("Europe");
                InsertContinent("Africa");
                InsertContinent("Australia");
                InsertContinent("Antarctica");
                InsertContinent("North America");
                InsertContinent("South America");
            }
        }


        public void InsertCountry(string countryName, int continentId, float area)
        {
            try
            {
                WorldDbDataContext db = new WorldDbDataContext(_connectionString);

                Country country = new Country();
                country.CountryName = countryName;
                country.ContinentId = continentId;
                country.Area = area;

                db.Countries.InsertOnSubmit(country);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void InsertAllCountries()
        {
            if (_newCountries)
            {
                InsertCountry("China", 1, 9597483);
                InsertCountry("Japan", 1, 377975);
                InsertCountry("Iraq", 1, 438317);
                InsertCountry("Thailand", 1, 513120);

                InsertCountry("Austria", 2, 83879);
                InsertCountry("Azerbaijan", 2, 86600);
                InsertCountry("Russia", 2, 17138547);
                InsertCountry("United Kingdom", 2, 242495);

                InsertCountry("Benin", 3, 114763);
                InsertCountry("Mozambique", 3, 801590);
                InsertCountry("Senegal", 3, 196722);
                InsertCountry("Zambia", 3, 752618);

                InsertCountry("Australia", 4, 7692843);

                InsertCountry("Bahamas", 6, 12880);
                InsertCountry("Canada", 6, 9985493);
                InsertCountry("Panama", 6, 75517);
                InsertCountry("Nicaragua", 6, 130370);

                InsertCountry("Argentina", 7, 2784358);
                InsertCountry("Chile", 7, 756950);
                InsertCountry("Uruguay", 7, 176215);
            }
        }


        public void InsertCity(string cityName, int countryId, int populationNumber, int isCapital)
        {
            try
            {
                WorldDbDataContext db = new WorldDbDataContext(_connectionString);

                City city = new City();
                city.CityName = cityName;
                city.CountryId = countryId;
                city.PopulationNumber = populationNumber;
                city.IsCapital = Convert.ToBoolean(isCapital);

                db.Cities.InsertOnSubmit(city);

                db.SubmitChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void InsertAllCities()
        {
            if (_newCities)
            {

                InsertCity("Beijing", 1, 22432484, 1);
                InsertCity("Chengdu", 1, 16943012, 0);
                InsertCity("Xian", 1, 8564737, 0);

                InsertCity("Tokyo", 2, 14939605, 1);
                InsertCity("Osaka", 2, 2843583, 0);
                InsertCity("Fukuoka", 2, 1643864, 0);

                InsertCity("Baghdad", 3, 77432853, 1);
                InsertCity("Mosul", 3, 1743753, 0);
                InsertCity("Ramadi", 3, 220000, 0);

                InsertCity("Bangkok", 4, 83475217, 1);
                InsertCity("Phuket", 4, 79000, 0);
                InsertCity("Krabi", 4, 33000, 0);

                InsertCity("Vienna", 5, 1700000, 1);
                InsertCity("Graz", 5, 290000, 0);
                InsertCity("Linz", 5, 190000, 0);

                InsertCity("Baku", 6, 2300000, 1);
                InsertCity("Sumqayit", 6, 360000, 0);
                InsertCity("Ganja", 6, 340000, 0);

                InsertCity("Moscow", 7, 12000000, 1);
                InsertCity("Vladivostok", 7, 590000, 0);
                InsertCity("Omsk", 7, 1200000, 0);

                InsertCity("London", 8, 9000000, 1);
                InsertCity("Livepool", 8, 470000, 0);
                InsertCity("Bristol", 8, 430000, 0);

                InsertCity("Porto-Novo", 9, 260000, 1);
                InsertCity("Cotonou", 9, 2400000, 0);
                InsertCity("Parakou", 9, 210000, 0);

                InsertCity("Maputo", 10, 1100000, 1);
                InsertCity("Pempa", 10, 200000, 0);
                InsertCity("Matola", 10, 1000000, 0);

                InsertCity("Dakar", 11, 1100000, 1);
                InsertCity("Touba", 11, 530000, 0);
                InsertCity("Tambacounda", 11, 79000, 0);

                InsertCity("Lusaka", 12, 1700000, 1);
                InsertCity("Ndola", 12, 450000, 0);
                InsertCity("Kasama", 12, 100000, 0);

                InsertCity("Canberra", 13, 1800000, 1);
                InsertCity("Gold Cost", 13, 3000000, 0);
                InsertCity("Darwin", 13, 130000, 0);

                InsertCity("Nassau", 14, 270000, 1);
                InsertCity("Coopers Town", 14, 680, 0);
                InsertCity("Marsh Harbour", 14, 6300, 0);

                InsertCity("Ottawa", 15, 930000, 1);
                InsertCity("Toronto", 15, 3000000, 0);
                InsertCity("Edmonton", 15, 970000, 0);

                InsertCity("Panama City", 16, 880000, 1);
                InsertCity("Tocumen", 16, 75000, 0);
                InsertCity("David", 16, 83000, 0);

                InsertCity("Managua", 17, 1100000, 1);
                InsertCity("Leon", 17, 210000, 0);
                InsertCity("Esteli", 17, 130000, 0);

                InsertCity("Buenos Aires", 18, 2900000, 1);
                InsertCity("Rosario", 18, 910000, 0);
                InsertCity("Mendoza", 18, 110000, 0);

                InsertCity("Santiago", 19, 6300000, 1);
                InsertCity("Iquique", 19, 190000, 0);
                InsertCity("Valparaiso", 19, 280000, 0);

                InsertCity("Montevideo", 20, 300000, 1);
                InsertCity("Minas", 20, 38000, 0);
                InsertCity("Saito", 20, 100000, 0);

            }
        }

        #endregion


        #region Updating Values

        public void UpdateContinent(int id, string newContinentName)
        {
            try
            {
                WorldDbDataContext db = new WorldDbDataContext(_connectionString);
                Continent continent = db.Continents.FirstOrDefault(c => c.Id == id);

                continent.ContinentName = newContinentName;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void UpdateCountry(int id, string newCountryName, int newContinentId, int newArea)
        {
            try
            {
                WorldDbDataContext db = new WorldDbDataContext(_connectionString);
                Country country = db.Countries.FirstOrDefault(c => c.Id == id);

                if (newCountryName != String.Empty) country.CountryName = newCountryName;
                if (newContinentId != -1) country.ContinentId = newContinentId;
                if (newArea != -1) country.Area = newArea;

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public void UpdateCity(int id, string newCityName, int newCountryId, int newPopulation, int newIsCapital)
        {
            try
            {
                WorldDbDataContext db = new WorldDbDataContext(_connectionString);
                City city = db.Cities.FirstOrDefault(c => c.Id == id);

                if (newCityName != String.Empty) city.CityName = newCityName;
                if (newCountryId != -1) city.CountryId = newCountryId;
                if (newPopulation != -1) city.PopulationNumber = newPopulation;
                if (newIsCapital != -1) city.IsCapital = Convert.ToBoolean(newIsCapital);

                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion


        #region Help Methods

        // Returns 'true' if query creates existing table
        // Returns 'false' otherwise
        private bool CheckTableExistance(string query)
        {
            SqlConnection connection = new SqlConnection(_connectionString);

            string tableName = GetTableNameFromQuery(query);

            connection.Open();

            List<string> tableNames = new List<string>();
            DataTable dataTable = connection.GetSchema("Tables");

            foreach (DataRow row in dataTable.Rows)
            {
                string dbTableName = row[2].ToString();

                if (dbTableName == tableName) return true;  // Table already exists in DB

            }

            return false;
        }


        // Gets create table query
        // Returns table Name
        private string GetTableNameFromQuery(string query)
        {
            string tableName = String.Empty;

            for (int i = 13; i < query.Length; i++)
            {
                if (query[i] == ' ' || query[i] == '\n' || query[i] == '(')
                {
                    break;
                }

                tableName += query[i];
            }

            return tableName;
        }

        #endregion

    }
}
