using System;
using System.Collections.Generic;
using ViralFinder.ViewModel;
using Xamarin.Forms;

namespace ViralFinder.View
{
    public partial class PageMaster : MasterDetailPage
    {
        PageMasterModel pageMasterModel;
        public PageMaster()
        {
            InitializeComponent();
            pageMasterModel = new PageMasterModel();
            BindingContext = pageMasterModel;
        }

        void impostazioni_Clicked(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new WelcomPage());
        }

        void Home_Clicked(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new PageMaster());
        }
    }
}
