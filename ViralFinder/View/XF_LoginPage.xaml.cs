using System;
using System.Collections.Generic;
using ViralFinder.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ViralFinder.View
{
    public partial class XF_LoginPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public XF_LoginPage()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
            BindingContext = loginViewModel;
        }
    }
}
