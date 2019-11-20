using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TregorTransport.Services;
using TregorTransport.Vues;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TregorTransport.VuesModeles
{
    class PrincipalVueModele : INotifyPropertyChanged
    {
        #region Attributs
        private readonly ApiAuthentification _apiServices = new ApiAuthentification();
        //private readonly ApiClient _apiServices2 = new ApiClient();

        private string _identifiant;
        private string _motDePasse;
        #endregion

        #region Constructeurs
        public PrincipalVueModele()
        {
            BoutonCommand = new Command(SwitchPageTest);
            //BoutonCommand = new Command(ActionPage);
        }
        #endregion

        #region Getters/Setters
        public ICommand BoutonCommand { get; }
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

        public ICommand ClickCommandURL => new Command<string>(async (url) =>
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
                Debug.WriteLine("Erreur lors de la redirection avec l'URL. Log de l'erreur :\n" + ex.Message);
            }

        });
        #endregion

        #region Methodes
        public void SwitchPageTest()
        {
            Application.Current.MainPage = new NavigationPage(new PageGeolocalisation());
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
