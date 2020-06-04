using System;
using System.Collections.Generic;
using ViralFinder.Model;
using ViralFinder.ViewModel;
using Xamarin.Forms;

namespace ViralFinder.View
{
    public partial class InstaLogin : ContentPage
    {
        InstaLoginModel instaLoginModel;
        public InstaLogin(Users user)
        {
            InitializeComponent();
            instaLoginModel = new InstaLoginModel(user);
            BindingContext = instaLoginModel;

        }
    }
}
