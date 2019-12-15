using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TregorTransport.Modeles;
using TregorTransport.Vues;

namespace TregorTransport.VuesModeles
{
    class MasterGeoVueModele : INotifyPropertyChanged
    {
        #region Attributs
        private string _utilisateur = "test";
        #endregion
        
        #region Constructeurs
        public MasterGeoVueModele()
        {
            foreach (User utilisateur in User.CollClasseUser)
            {
                _utilisateur = utilisateur.username;
            }
            MenuItems = new ObservableCollection<MasterDetailGeoMasterMenuItem>(new[]
            {
                new MasterDetailGeoMasterMenuItem { Id = 0, Title = "Mon compte", Image = "iconUser.png", Width = "32", Height = "32" },
                new MasterDetailGeoMasterMenuItem { Id = 1, Title = "Mes trajets", Image = "iconBus.png", Width = "32", Height = "32" },
                new MasterDetailGeoMasterMenuItem { Id = 2, Title = "Réserver un trajet", Image = "iconTicket.png", Width = "35", Height = "35" },

            });
        }
        #endregion

        #region Getters/Setters
        public ObservableCollection<MasterDetailGeoMasterMenuItem> MenuItems { get; set; }
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
