﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TregorTransport.Modeles;
using Xamarin.Forms;

namespace TregorTransport.VuesModeles
{
    class GeolocalisationVueModele : INotifyPropertyChanged
    {
        #region Attributs
        Geolocalisation laGeolocalisation = new Geolocalisation(0.000, 0.000);
        #endregion

        #region Constructeur
        public GeolocalisationVueModele()
        {
            BoutonCommandTest = new Command(AjoutGeo);
        }
        #endregion

        #region Getters/Setters
        public ICommand BoutonCommandTest { get; }

        public double Latitude { get { return laGeolocalisation.Latitude; } set { laGeolocalisation.Latitude = value; OnPropertyChanged(nameof(Latitude)); } }
        public double Longitude { get { return laGeolocalisation.Longitude; } set { laGeolocalisation.Longitude = value; OnPropertyChanged(nameof(laGeolocalisation.Longitude)); } }

        #endregion

        #region Methodes
        public async void AjoutGeo()
        {
            var uneGeo = await Geolocalisation.GetLocalisation();
            Latitude = uneGeo.Latitude;
            Longitude = uneGeo.Longitude;

        }
        #endregion

        #region Notification
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}