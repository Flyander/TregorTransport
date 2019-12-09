using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TregorTransport.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailGeoMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetailGeoMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailGeoMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailGeoMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailGeoMasterMenuItem> MenuItems { get; set; }

            public MasterDetailGeoMasterViewModel()
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

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}