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
            foreach (User utilisateur in User.CollClasseUser) // Set User binding in view with the User class
            {
                _utilisateur = utilisateur.username; 
            }
            MenuItems = new ObservableCollection<MasterDetailGeoMasterMenuItem>(new[] // Add items in Master page
            {
                new MasterDetailGeoMasterMenuItem { Id = 0, Title = "Géolocalisation", Image = "iconGeo.png", Width = "34", Height = "34", TargetType = typeof(MasterDetailGeo) },
                new MasterDetailGeoMasterMenuItem { Id = 1, Title = "Mon compte", Image = "iconUser.png", Width = "34", Height = "34", TargetType = typeof(PageCompte) },
                new MasterDetailGeoMasterMenuItem { Id = 2, Title = "Mes trajets", Image = "iconBus.png", Width = "34", Height = "34", TargetType = typeof(PageTrajet) },
                new MasterDetailGeoMasterMenuItem { Id = 3, Title = "Réserver un trajet", Image = "iconTicket.png", Width = "37", Height = "37", TargetType = typeof(PageReserver) },

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
