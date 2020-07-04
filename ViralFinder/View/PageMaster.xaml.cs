using System;
using System.Collections.Generic;
using ViralFinder.ViewModel;
using Xamarin.Forms;
using ViralFinder.Classi;
using InstagramApiSharp.API;
using ViralFinder.Model;
using System.Linq;
using SkiaSharp;
using Microcharts;

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
            pageMasterModel = new PageMasterModel(insta, user, Grafico, GraficoCommenti);
            BindingContext = pageMasterModel;
            this.insta = insta;
            this.user = user;
        }




        void impostazioni_Clicked(System.Object sender, System.EventArgs e)
        {
            NavigationPage.SetHasNavigationBar(this,false);
            Detail = new WelcomPage(user);
            
        }

        void Home_Clicked(System.Object sender, System.EventArgs e)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Detail = new PageMaster(insta, user);
          
            //Detail = new NavigationPage(new PageMaster(user));
        }

        void ricercheSalvate_Clicked(System.Object sender, System.EventArgs e)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Detail = new OldHashtag(this.user, insta);
           
        }

    }
}
