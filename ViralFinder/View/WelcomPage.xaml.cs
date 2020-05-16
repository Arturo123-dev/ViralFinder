using System;
using System.Collections.Generic;
using ViralFinder.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ViralFinder.View
{
	public partial class WelcomPage : ContentPage
	{
		WelcomePageVM welcomePageVM;
		public WelcomPage()
		{
			InitializeComponent();
			welcomePageVM = new WelcomePageVM();
			BindingContext = welcomePageVM;
		}
	}
}
