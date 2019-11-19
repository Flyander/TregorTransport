using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task<Geolocalisation> GetLocalisation()
        {
            Geolocalisation localisation = null;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    localisation = new Geolocalisation(location.Latitude, location.Longitude);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                //return "Erreur, le téléphone ne supporte pas la géolocalisation";
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // return "Erreur, le téléphone ne supporte pas la géolocalisation";
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                //return "Erreur, le téléphone ne supporte pas la géolocalisation";
                // Handle permission exception
            }
            catch (Exception ex)
            {
                //return "Erreur, le téléphone ne supporte pas la géolocalisation";
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
