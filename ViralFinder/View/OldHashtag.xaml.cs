using System;
using System.Collections.Generic;
using Firebase.Auth;
using ViralFinder.Classi;
using ViralFinder.Model;
using ViralFinder.ViewModel;
using Xamarin.Forms;

namespace ViralFinder.View
{
    public partial class OldHashtag : ContentPage
    {

        Users user;
        private InstaClass insta;

        OldHashtagModel pageModel;

        public OldHashtag(Users user, InstaClass insta, List<InstaSearchData> data)
        {
            InitializeComponent();
            this.user = user;
            this.insta = insta;
            pageModel = new OldHashtagModel(user, insta, data);
            BindingContext = pageModel;
        }
    }
}
