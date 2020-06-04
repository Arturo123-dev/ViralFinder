using System;
using System.Collections.Generic;
using ViralFinder.Model;
using ViralFinder.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ViralFinder.View
{
	public partial class WelcomPage : ContentPage
	{
		WelcomePageVM welcomePageVM;
		public WelcomPage(Users user)
		{
			InitializeComponent();
			welcomePageVM = new WelcomePageVM(user);
			BindingContext = welcomePageVM;
		}
	}
}
