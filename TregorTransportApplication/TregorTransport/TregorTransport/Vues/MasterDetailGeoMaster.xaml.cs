using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TregorTransport.VuesModeles;
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

            BindingContext = new MasterGeoVueModele();
            ListView = MenuItemsListView;
        }

    }
}