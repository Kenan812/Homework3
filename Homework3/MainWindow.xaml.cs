using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=World;Integrated Security=True";
        private WorldDbDataContext _db = new WorldDbDataContext(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=World;Integrated Security=True");
        private TableCreate _tc;
        private AllQueries _allQueries;

        private bool _isInsert = false;
        private bool _isUpdate = false;
        private bool _isDelete = false;

        private bool _isContinents = false;
        private bool _isCountries = false;
        private bool _isCities = false;

        public MainWindow()
        {
            InitializeComponent();

            _tc = new TableCreate(_connectionString);
            _allQueries = new AllQueries(_connectionString);
        }

        private void createTablesButton_Click(object sender, RoutedEventArgs e)
        {
            _tc.CreateAllTables();
            _tc.InsertAllValues();
        }



        #region Main Queries

        private void showAllContinentsComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _allQueries.GetAllContinents();
        }

        private void showAllCountriesComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _allQueries.GetAllCountries();
        }

        private void showAllCitiesComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _allQueries.GetAllCities();
        }

        private void showCountryByContinent_Selected(object sender, RoutedEventArgs e)
        {
            choiseComboBox.IsEnabled = true;

            try
            {
                choiseComboBox.ItemsSource = _allQueries.GetContinentsByTypeSpecifically().Select(c => c.ContinentName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void showCityByCountry_Selected(object sender, RoutedEventArgs e)
        {
            choiseComboBox.IsEnabled = true;

            try
            {
                choiseComboBox.ItemsSource = _allQueries.GetCountriesByTypeSpecifically().Select(c => c.CountryName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void choiseComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox cb = (sender as ComboBox);

                if ((mainComboBox.SelectedItem as ComboBoxItem).Name == "showCountryByContinent")
                    tableDataGrid.ItemsSource = _allQueries.GetCountryByContinent(cb.SelectedItem.ToString());

                else if ((mainComboBox.SelectedItem as ComboBoxItem).Name == "showCityByCountry")
                    tableDataGrid.ItemsSource = _allQueries.GetCityByCountry(cb.SelectedItem.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

        }

        private void showAllCapitalsComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _allQueries.GetAllCapitals();
        }

        private void showTop5CountriesByAreaComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _allQueries.GetTop5CountriesByArea();
        }

        private void showTop5CountriesByPopulationComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _allQueries.GetTop5CountriesByPopulation();
        }

        private void showTop5CitiesByPopulationComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _allQueries.GetTop5CitiesByPopulation();
        }

        private void showTop3ContinentsByAreaComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _allQueries.GetTop3ContinentsByArea();
        }

        private void showTop3ContinentsByPopulationComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            tableDataGrid.ItemsSource = _allQueries.GetTop3ContinentsByPopulation();

        }

        #endregion


        #region ISNERT UPDATE DELETE

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            BringToInitialCondition();
            _isInsert = true;

            continentsButton.IsEnabled = true;
            countriesButton.IsEnabled = true;
            citiesButton.IsEnabled = true;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            BringToInitialCondition();
            _isUpdate = true;

            continentsButton.IsEnabled = true;
            countriesButton.IsEnabled = true;
            citiesButton.IsEnabled = true;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            BringToInitialCondition();
            _isDelete = true;

            continentsButton.IsEnabled = true;
            countriesButton.IsEnabled = true;
            citiesButton.IsEnabled = true;
        }

        #endregion




        private void continentsButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isInsert)
            {
                label1.Content = "Continent name";
                textBox1.IsEnabled = true;

                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;

                textBox2.IsEnabled = false;
                textBox3.IsEnabled = false;
                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;

                label2.Content = "N/A";
                label3.Content = "N/A";
                label4.Content = "N/A";
                label5.Content = "N/A";
            }

            else if (_isUpdate)
            {
                label1.Content = "Continent id to update";
                textBox1.IsEnabled = true;
                label2.Content = "New continent name";
                textBox2.IsEnabled = true;

                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;

                textBox3.IsEnabled = false;
                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;

                label3.Content = "N/A";
                label4.Content = "N/A";
                label5.Content = "N/A";
            }

            else if (_isDelete)
            {
                label1.Content = "Continent id to delete";
                textBox1.IsEnabled = true;

                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;

                textBox2.IsEnabled = false;
                textBox3.IsEnabled = false;
                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;

                label2.Content = "N/A";
                label3.Content = "N/A";
                label4.Content = "N/A";
                label5.Content = "N/A";
            }

            saveButton.IsEnabled = true;
            _isContinents = true;
            _isCountries = false;
            _isCities = false;
        }


        private void countriesButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isInsert)
            {
                label1.Content = "Country name";
                textBox1.IsEnabled = true;
                label2.Content = "Continent Id";
                textBox2.IsEnabled = true;
                label3.Content = "Area";
                textBox3.IsEnabled = true;
                saveButton.IsEnabled = true;

                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;

                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;

                label4.Content = "N/A";
                label5.Content = "N/A";
            }

            else if (_isUpdate)
            {
                MessageBox.Show("Leave text box empty if no change in this column", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                label1.Content = "Country id to update";
                textBox1.IsEnabled = true;
                label2.Content = "New country name";
                textBox2.IsEnabled = true;
                label3.Content = "New continent id";
                textBox3.IsEnabled = true;
                label4.Content = "New area";
                textBox4.IsEnabled = true;


                textBox5.Text = String.Empty;

                textBox5.IsEnabled = false;

                label5.Content = "N/A";
            }

            else if (_isDelete)
            {
                label1.Content = "Country id to delete";
                textBox1.IsEnabled = true;

                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;

                textBox2.IsEnabled = false;
                textBox3.IsEnabled = false;
                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;

                label2.Content = "N/A";
                label3.Content = "N/A";
                label4.Content = "N/A";
                label5.Content = "N/A";
            }

            saveButton.IsEnabled = true;
            _isCountries = true;
            _isContinents = false;
            _isCities = false;
        }


        private void citiesButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isInsert)
            {
                label1.Content = "City name";
                textBox1.IsEnabled = true;
                label2.Content = "Country Id";
                textBox2.IsEnabled = true;
                label3.Content = "Population number";
                textBox3.IsEnabled = true;
                label4.Content = "Is capital(1-yes/2-no)";
                textBox4.IsEnabled = true;

                textBox5.Text = String.Empty;
                textBox5.IsEnabled = false;
                label5.Content = "N/A";
            }

            else if (_isUpdate)
            {
                MessageBox.Show("Leave text box empty if no change in this column", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                label1.Content = "City id to update";
                textBox1.IsEnabled = true;
                label2.Content = "New city name";
                textBox2.IsEnabled = true;
                label3.Content = "New country id";
                textBox3.IsEnabled = true;
                label4.Content = "New population";
                textBox4.IsEnabled = true;
                label5.Content = "Is capital(1-yes/0-no)";
                textBox5.IsEnabled = true;
            }

            else if (_isDelete)
            {
                label1.Content = "City id to delete";
                textBox1.IsEnabled = true;

                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text = String.Empty;
                textBox5.Text = String.Empty;

                textBox2.IsEnabled = false;
                textBox3.IsEnabled = false;
                textBox4.IsEnabled = false;
                textBox5.IsEnabled = false;

                label2.Content = "N/A";
                label3.Content = "N/A";
                label4.Content = "N/A";
                label5.Content = "N/A";
            }

            saveButton.IsEnabled = true;
            _isCities = true;
            _isCountries = false;
            _isContinents = false;
        }


        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isInsert)
            {
                SaveInsert();
            }

            else if (_isUpdate)
            {
                SaveUpdate();
            }

            else if (_isDelete)
            {
                SaveDelete();
            }

            BringToInitialCondition();
        }


        #region Save Operations

        private void SaveInsert()
        {
            if (_isContinents && textBox1.Text != String.Empty)
            {
                _tc.InsertContinent(textBox1.Text);
            }

            else if (_isCountries && textBox1.Text != String.Empty && textBox2.Text != String.Empty && textBox3.Text != String.Empty)
            {
                try
                {
                    _tc.InsertCountry(textBox1.Text, Int32.Parse(textBox2.Text), float.Parse(textBox3.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (_isCities && textBox1.Text != String.Empty && textBox2.Text != String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty)
            {
                try
                {
                    _tc.InsertCity(textBox1.Text, Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveUpdate()
        {
            if (_isContinents && textBox1.Text != String.Empty && textBox2.Text != String.Empty)
            {
                try
                {
                    _tc.UpdateContinent(Int32.Parse(textBox1.Text), textBox2.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (_isCountries && textBox1.Text != String.Empty)
            {
                try
                {
                    int continentId;
                    int area;

                    if (textBox3.Text == String.Empty) continentId = -1;
                    else continentId = Int32.Parse(textBox3.Text);

                    if (textBox4.Text == String.Empty) area = -1;
                    else area = Int32.Parse(textBox4.Text);

                    _tc.UpdateCountry(Int32.Parse(textBox1.Text), textBox2.Text, continentId, area);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (_isCities && textBox1.Text != String.Empty)
            {
                try
                {
                    int countryId;
                    int population;
                    int iscapital;

                    if (textBox3.Text == String.Empty) countryId = -1;
                    else countryId = Int32.Parse(textBox3.Text);

                    if (textBox4.Text == String.Empty) population = -1;
                    else population = Int32.Parse(textBox4.Text);

                    if (textBox5.Text == String.Empty) iscapital = -1;
                    else iscapital = Int32.Parse(textBox5.Text);

                    _tc.UpdateCity(Int32.Parse(textBox1.Text), textBox2.Text, countryId, population, iscapital);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }



        }

        private void SaveDelete()
        {
            if (_isContinents && textBox1.Text != String.Empty)
            {
                try
                {
                    _tc.DeleteContinent(Int32.Parse(textBox1.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (_isCountries && textBox1.Text != String.Empty)
            {
                try
                {
                    _tc.DeleteCountry(Int32.Parse(textBox1.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else if (_isCities && textBox1.Text != String.Empty)
            {
                try
                {
                    _tc.DeleteCity(Int32.Parse(textBox1.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        #endregion


        private void BringToInitialCondition()
        {
            saveButton.IsEnabled = false;
            continentsButton.IsEnabled = false;
            countriesButton.IsEnabled = false;
            citiesButton.IsEnabled = false;

            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;

            textBox1.IsEnabled = false;
            textBox2.IsEnabled = false;
            textBox3.IsEnabled = false;
            textBox4.IsEnabled = false;
            textBox5.IsEnabled = false;

            label1.Content = "N/A";
            label2.Content = "N/A";
            label3.Content = "N/A";
            label4.Content = "N/A";
            label5.Content = "N/A";

            _isInsert = false;
            _isUpdate = false;
            _isDelete = false;

            _isCities = false;
            _isCountries = false;
            _isContinents = false;
        }

        
    }
}
