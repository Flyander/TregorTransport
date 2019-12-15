using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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

        private string _identifiant = "";
        private bool _isBusy = false;
        private bool _isBusyReverse = true;
        private bool _isBusyError = false;
        private string _motDePasse = "";
        #endregion

        #region Constructeurs
        public PrincipalVueModele()
        {
            BoutonCommand = new Command(TryConnect);
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
        public string Identifiant
        {
            get
            {
                return _identifiant;
            }
            set
            {
                if (_identifiant != value)
                {
                    _identifiant = value;
                    OnPropertyChanged(nameof(Identifiant));
                }
            }
        }
        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }
            set
            {
                if (_motDePasse != value)
                {
                    _motDePasse = value;
                    OnPropertyChanged(nameof(MotDePasse));
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }
        public bool IsBusyError
        {
            get
            {
                return _isBusyError;
            }
            set
            {
                if (_isBusyError != value)
                {
                    _isBusyError = value;
                    OnPropertyChanged(nameof(IsBusyError));
                }
            }
        }
        public bool IsBusyReverse
        {
            get
            {
                return _isBusyReverse;
            }
            set
            {
                if (_isBusyReverse != value)
                {
                    _isBusyReverse = value;
                    OnPropertyChanged(nameof(IsBusyReverse));
                }
            }
        }

        #endregion

        #region Methodes

        public void TryConnect()
        {
            Task.Run(async () =>
            {
                IsBusy = true;
                IsBusyReverse = false;
                if (await _apiServices.GetAuthAsync(Identifiant, MotDePasse))
                {
                    IsBusyReverse = true;
                    IsBusy = false;
                    await Task.Delay(50);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Application.Current.MainPage = (new MasterDetailGeo());
                    });
                }
                else
                {
                    await Task.Delay(300);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        test();
                    });
                    IsBusyReverse = true;
                    IsBusy = false;
                    IsBusyError = true;
                }

            });
        }
        
        public async void test()
        {
            await Application.Current.MainPage.DisplayAlert("Attention !", "Le mot de passe actuel ou l'email saisi n'est pas correct.", "Ok");

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
