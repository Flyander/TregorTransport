using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TregorTransport.Modeles;
using Xamarin.Essentials;
using Xamarin.Forms;
using xMap = Xamarin.Forms.Maps; // using xMap for counter bug with Xmarin.Essentials.Map and Xamarin.Forms.Maps.Map

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
            Map = new xMap.Map();
            StartEmplacement();
        }
        #endregion

        #region Getters/Setters
        public xMap.Map Map { get; private set; }
        public double Latitude { get { return laGeolocalisation.Latitude; } set { laGeolocalisation.Latitude = value; OnPropertyChanged(nameof(Latitude)); } }
        public double Longitude { get { return laGeolocalisation.Longitude; } set { laGeolocalisation.Longitude = value; OnPropertyChanged(nameof(laGeolocalisation.Longitude)); } }

        #endregion

        #region Methodes
        public async void StartEmplacement() // start map on user postion
        {
            var uneGeo = await Geolocalisation.GetLocalisation();
            Latitude = uneGeo.Latitude;
            Longitude = uneGeo.Longitude;
            Map.IsShowingUser = true;
            Map.MoveToRegion(xMap.MapSpan.FromCenterAndRadius(new xMap.Position(Latitude, Longitude), xMap.Distance.FromKilometers(0.5)));
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
