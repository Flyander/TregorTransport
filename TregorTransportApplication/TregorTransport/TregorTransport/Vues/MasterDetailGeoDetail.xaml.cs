using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TregorTransport.VuesModeles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TregorTransport.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailGeoDetail : ContentPage
    {
        public MasterDetailGeoDetail()
        {
            InitializeComponent();
            BindingContext = new GeolocalisationVueModele();
        }
    }
}