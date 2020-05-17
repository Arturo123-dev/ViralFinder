using System;
using System.Collections.Generic;
using ViralFinder.ViewModel;
using Xamarin.Forms;

namespace ViralFinder.View
{
    public partial class InstaLogin : ContentPage
    {
        InstaLoginModel instaLoginModel;
        public InstaLogin()
        {
            InitializeComponent();
            instaLoginModel = new InstaLoginModel();
            BindingContext = instaLoginModel;

        }
    }
}
