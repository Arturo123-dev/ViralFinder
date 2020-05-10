using System;
using System.Diagnostics;
using ViralFinder.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ViralFinder
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new XF_LoginPage());
        }

        protected override void OnStart()
        {
            Console.WriteLine("App start");
            Debug.WriteLine("App starts");
        }

        protected override void OnSleep()
        {
            Console.WriteLine("App sleep");
            Debug.WriteLine("App sleeps");
        }

        protected override void OnResume()
        {
            Console.WriteLine("App resume");
            Debug.WriteLine("App resumes");
        }
    }
}
