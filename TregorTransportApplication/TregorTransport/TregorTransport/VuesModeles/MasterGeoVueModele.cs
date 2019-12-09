using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TregorTransport.Vues;

namespace TregorTransport.VuesModeles
{
    class MasterGeoVueModele : INotifyPropertyChanged
    {
        #region Attributs
        private string _utilisateur = "test";
        #endregion
        public ObservableCollection<MasterDetailGeoMasterMenuItem> MenuItems { get; set; }
        #region Constructeurs
        public MasterGeoVueModele()
        {
            MenuItems = new ObservableCollection<MasterDetailGeoMasterMenuItem>(new[]
            {
                new MasterDetailGeoMasterMenuItem { Id = 0, Title = "Page 1" },
                new MasterDetailGeoMasterMenuItem { Id = 1, Title = "Page 2" },
                new MasterDetailGeoMasterMenuItem { Id = 2, Title = "Page 3" },
                new MasterDetailGeoMasterMenuItem { Id = 3, Title = "Page 4" },
                new MasterDetailGeoMasterMenuItem { Id = 4, Title = "Page 5" },
            });
        }
        #endregion


        #region Methodes
        public string Utilisateur { get { return _utilisateur; } set { _utilisateur = value; OnPropertyChanged(nameof(Utilisateur)); } }
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
