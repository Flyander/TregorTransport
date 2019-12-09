using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TregorTransport.Modeles
{
    class Geolocalisation
    {
        #region Attributs
        private double _latitude;
        private double _longitude;
        #endregion

        #region Constructeur
        public Geolocalisation(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        #endregion

        #region Getters/Setters

        public double Latitude { get => _latitude; set => _latitude = value; }
        public double Longitude { get => _longitude; set => _longitude = value; }
        #endregion

        #region Methodes
        public static async Task<Geolocalisation> GetLocalisation()
        {
            Geolocalisation localisation = null;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    localisation = new Geolocalisation(location.Latitude, location.Longitude);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Debug.Print("Erreur, le téléphone ne supporte pas la géolocalisation.\n Message d'erreur :" + fnsEx);
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Debug.Print("Erreur, la géolocalisation n'est pas active sur votre téléphone.\n Message d'erreur :" + fneEx);
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                Debug.Print("Erreur, les permissions pour l'utilisation du GPS n'est pas valide.\n Message d'erreur :)" + pEx);
                // Handle permission exception
            }
            catch (Exception ex)
            {
                Debug.Print("Erreur, le téléphone ne supporte pas la géolocalisation.\n Message d'erreur :" + ex);
                // Unable to get location
            }
            return localisation;
        }

        public static double CalculateDistance(Geolocalisation param1, Geolocalisation param2)
        {
            Location pointA = new Location(param1.Latitude, param1.Longitude);
            Location pointB = new Location(param2.Latitude, param2.Longitude);

            return Location.CalculateDistance(pointA, pointB, DistanceUnits.Kilometers);
        }
        #endregion
    }
}
