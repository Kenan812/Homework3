﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Homework3
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="World")]
	public partial class WorldDbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCity(City instance);
    partial void UpdateCity(City instance);
    partial void DeleteCity(City instance);
    partial void InsertContinent(Continent instance);
    partial void UpdateContinent(Continent instance);
    partial void DeleteContinent(Continent instance);
    partial void InsertCountry(Country instance);
    partial void UpdateCountry(Country instance);
    partial void DeleteCountry(Country instance);
    #endregion
		
		public WorldDbDataContext() : 
				base(global::Homework3.Properties.Settings.Default.WorldConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public WorldDbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WorldDbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WorldDbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public WorldDbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<City> Cities
		{
			get
			{
				return this.GetTable<City>();
			}
		}
		
		public System.Data.Linq.Table<Continent> Continents
		{
			get
			{
				return this.GetTable<Continent>();
			}
		}
		
		public System.Data.Linq.Table<Country> Countries
		{
			get
			{
				return this.GetTable<Country>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cities")]
	public partial class City : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _CityName;
		
		private System.Nullable<int> _CountryId;
		
		private System.Nullable<int> _PopulationNumber;
		
		private System.Nullable<bool> _IsCapital;
		
		private EntityRef<Country> _Country;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCityNameChanging(string value);
    partial void OnCityNameChanged();
    partial void OnCountryIdChanging(System.Nullable<int> value);
    partial void OnCountryIdChanged();
    partial void OnPopulationNumberChanging(System.Nullable<int> value);
    partial void OnPopulationNumberChanged();
    partial void OnIsCapitalChanging(System.Nullable<bool> value);
    partial void OnIsCapitalChanged();
    #endregion
		
		public City()
		{
			this._Country = default(EntityRef<Country>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CityName", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
		public string CityName
		{
			get
			{
				return this._CityName;
			}
			set
			{
				if ((this._CityName != value))
				{
					this.OnCityNameChanging(value);
					this.SendPropertyChanging();
					this._CityName = value;
					this.SendPropertyChanged("CityName");
					this.OnCityNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryId", DbType="Int")]
		public System.Nullable<int> CountryId
		{
			get
			{
				return this._CountryId;
			}
			set
			{
				if ((this._CountryId != value))
				{
					if (this._Country.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnCountryIdChanging(value);
					this.SendPropertyChanging();
					this._CountryId = value;
					this.SendPropertyChanged("CountryId");
					this.OnCountryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PopulationNumber", DbType="Int")]
		public System.Nullable<int> PopulationNumber
		{
			get
			{
				return this._PopulationNumber;
			}
			set
			{
				if ((this._PopulationNumber != value))
				{
					this.OnPopulationNumberChanging(value);
					this.SendPropertyChanging();
					this._PopulationNumber = value;
					this.SendPropertyChanged("PopulationNumber");
					this.OnPopulationNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsCapital", DbType="Bit")]
		public System.Nullable<bool> IsCapital
		{
			get
			{
				return this._IsCapital;
			}
			set
			{
				if ((this._IsCapital != value))
				{
					this.OnIsCapitalChanging(value);
					this.SendPropertyChanging();
					this._IsCapital = value;
					this.SendPropertyChanged("IsCapital");
					this.OnIsCapitalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_City", Storage="_Country", ThisKey="CountryId", OtherKey="Id", IsForeignKey=true)]
		public Country Country
		{
			get
			{
				return this._Country.Entity;
			}
			set
			{
				Country previousValue = this._Country.Entity;
				if (((previousValue != value) 
							|| (this._Country.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Country.Entity = null;
						previousValue.Cities.Remove(this);
					}
					this._Country.Entity = value;
					if ((value != null))
					{
						value.Cities.Add(this);
						this._CountryId = value.Id;
					}
					else
					{
						this._CountryId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Country");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Continents")]
	public partial class Continent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _ContinentName;
		
		private EntitySet<Country> _Countries;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnContinentNameChanging(string value);
    partial void OnContinentNameChanged();
    #endregion
		
		public Continent()
		{
			this._Countries = new EntitySet<Country>(new Action<Country>(this.attach_Countries), new Action<Country>(this.detach_Countries));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContinentName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string ContinentName
		{
			get
			{
				return this._ContinentName;
			}
			set
			{
				if ((this._ContinentName != value))
				{
					this.OnContinentNameChanging(value);
					this.SendPropertyChanging();
					this._ContinentName = value;
					this.SendPropertyChanged("ContinentName");
					this.OnContinentNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Continent_Country", Storage="_Countries", ThisKey="Id", OtherKey="ContinentId")]
		public EntitySet<Country> Countries
		{
			get
			{
				return this._Countries;
			}
			set
			{
				this._Countries.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Countries(Country entity)
		{
			this.SendPropertyChanging();
			entity.Continent = this;
		}
		
		private void detach_Countries(Country entity)
		{
			this.SendPropertyChanging();
			entity.Continent = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Countries")]
	public partial class Country : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _CountryName;
		
		private System.Nullable<int> _ContinentId;
		
		private double _Area;
		
		private EntitySet<City> _Cities;
		
		private EntityRef<Continent> _Continent;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnCountryNameChanging(string value);
    partial void OnCountryNameChanged();
    partial void OnContinentIdChanging(System.Nullable<int> value);
    partial void OnContinentIdChanged();
    partial void OnAreaChanging(double value);
    partial void OnAreaChanged();
    #endregion
		
		public Country()
		{
			this._Cities = new EntitySet<City>(new Action<City>(this.attach_Cities), new Action<City>(this.detach_Cities));
			this._Continent = default(EntityRef<Continent>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountryName", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
		public string CountryName
		{
			get
			{
				return this._CountryName;
			}
			set
			{
				if ((this._CountryName != value))
				{
					this.OnCountryNameChanging(value);
					this.SendPropertyChanging();
					this._CountryName = value;
					this.SendPropertyChanged("CountryName");
					this.OnCountryNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ContinentId", DbType="Int")]
		public System.Nullable<int> ContinentId
		{
			get
			{
				return this._ContinentId;
			}
			set
			{
				if ((this._ContinentId != value))
				{
					if (this._Continent.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnContinentIdChanging(value);
					this.SendPropertyChanging();
					this._ContinentId = value;
					this.SendPropertyChanged("ContinentId");
					this.OnContinentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Area", DbType="Float NOT NULL")]
		public double Area
		{
			get
			{
				return this._Area;
			}
			set
			{
				if ((this._Area != value))
				{
					this.OnAreaChanging(value);
					this.SendPropertyChanging();
					this._Area = value;
					this.SendPropertyChanged("Area");
					this.OnAreaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Country_City", Storage="_Cities", ThisKey="Id", OtherKey="CountryId")]
		public EntitySet<City> Cities
		{
			get
			{
				return this._Cities;
			}
			set
			{
				this._Cities.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Continent_Country", Storage="_Continent", ThisKey="ContinentId", OtherKey="Id", IsForeignKey=true)]
		public Continent Continent
		{
			get
			{
				return this._Continent.Entity;
			}
			set
			{
				Continent previousValue = this._Continent.Entity;
				if (((previousValue != value) 
							|| (this._Continent.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Continent.Entity = null;
						previousValue.Countries.Remove(this);
					}
					this._Continent.Entity = value;
					if ((value != null))
					{
						value.Countries.Add(this);
						this._ContinentId = value.Id;
					}
					else
					{
						this._ContinentId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Continent");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Cities(City entity)
		{
			this.SendPropertyChanging();
			entity.Country = this;
		}
		
		private void detach_Cities(City entity)
		{
			this.SendPropertyChanging();
			entity.Country = null;
		}
	}
}
#pragma warning restore 1591
