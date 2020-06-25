using System;
using System.Collections.Generic;
using Firebase.Auth;
using ViralFinder.Model;
using Xamarin.Forms;

namespace ViralFinder.View
{
    public partial class OldHashtag : ContentPage
    {

        Users user;

        public OldHashtag(Users user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}
