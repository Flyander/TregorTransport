using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TregorTransport.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailGeo : MasterDetailPage
    {
        public MasterDetailGeo()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailGeoMasterMenuItem;
            if (item == null)
                return;

            var page = Activator.CreateInstance(item.TargetType);

           
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}