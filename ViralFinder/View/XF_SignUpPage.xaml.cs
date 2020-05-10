using System;
using System.Collections.Generic;
using ViralFinder.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ViralFinder.View
{
    public partial class XF_SignUpPage : ContentPage
    {
        SignUpVM signUpVM;
        public XF_SignUpPage()
        {
            InitializeComponent();
            signUpVM = new SignUpVM();
            //set binding
            BindingContext = signUpVM;
        }
    }
}
