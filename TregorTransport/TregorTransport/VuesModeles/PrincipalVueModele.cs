using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
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
        private Boolean IsValidUri(String uri)
        {
            try
            {
                new Uri(uri);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ICommand ClickCommand => new Command<string>(async (url) =>
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    if (!url.Trim().StartsWith("http", StringComparison.OrdinalIgnoreCase))
                    {
                        url = "http://" + url;
                    }
                    if (IsValidUri(url))
                    {
                        await Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        });
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
