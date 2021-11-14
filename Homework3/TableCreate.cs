using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            InsertAllContinents();



            _connection.Close();
        }

        #region Inserting Values

        private void InsertContinent(string continentName)
        {
            string query = $"INSERT INTO Continents(ContinentName) VALUES('{continentName}')";

            SqlCommand command = new SqlCommand(query, _connection);

            command.ExecuteNonQuery();
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


        private void InsertCountry(string countryName, int continentId, float area)
        {
            string query = $"INSERT INTO Countries(CountryName, ContinentId, Area) VALUES('{countryName}', {continentId}, {area})";

            SqlCommand command = new SqlCommand(query, _connection);

            command.ExecuteNonQuery();
        }

        private void InsertAllCountries()
        {
            if (_newCountries)
            {

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
