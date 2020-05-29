using System;
using System.Collections.Generic;
using ViralFinder.ViewModel;
using Xamarin.Forms;
using ViralFinder.Classi;
using InstagramApiSharp.API;

namespace ViralFinder.View
{
    public partial class PageMaster : MasterDetailPage
    {
        PageMasterModel pageMasterModel;

        private InstaClass insta;



        public PageMaster()
        {
            InitializeComponent();
            pageMasterModel = new PageMasterModel();
            BindingContext = pageMasterModel;
        }

        public PageMaster(InstaClass insta)
        {
            InitializeComponent();
            pageMasterModel = new PageMasterModel(insta);
            BindingContext = pageMasterModel;
            this.insta = insta;   
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
