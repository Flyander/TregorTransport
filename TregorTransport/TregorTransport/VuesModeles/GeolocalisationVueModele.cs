using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TregorTransport.Services;
using System.Text;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace TregorTransport.VuesModeles
{
    class GeolocalisationVueModele : INotifyPropertyChanged
    {
        #region Attributs

        #endregion

        #region Constructeur
        public GeolocalisationVueModele()
        {
        }
        #endregion

        #region Getters/Setters
        #endregion

        #region Methodes
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
