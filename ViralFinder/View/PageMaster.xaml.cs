using System;
using System.Collections.Generic;
using ViralFinder.ViewModel;
using Xamarin.Forms;
using ViralFinder.Classi;
using InstagramApiSharp.API;
using ViralFinder.Model;

namespace ViralFinder.View
{
    public partial class PageMaster : MasterDetailPage
    {
        PageMasterModel pageMasterModel;

        private InstaClass insta;

        Users user;

        public PageMaster(Users user)
        {
            this.user = user;
            InitializeComponent();
            pageMasterModel = new PageMasterModel();
            BindingContext = pageMasterModel;
        }

        public PageMaster(InstaClass insta, Users user)
        {
            InitializeComponent();
            pageMasterModel = new PageMasterModel(insta, user);
            BindingContext = pageMasterModel;
            this.insta = insta;   
        }



        void impostazioni_Clicked(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new WelcomPage(user));
        }

        void Home_Clicked(System.Object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new PageMaster(user));
        }
    }
}
