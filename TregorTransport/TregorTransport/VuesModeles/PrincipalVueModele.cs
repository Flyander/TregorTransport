using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TregorTransport.VuesModeles
{
    class PrincipalVueModele : INotifyPropertyChanged
    {
        #region Attributs
        #endregion

        #region Constructeurs
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
