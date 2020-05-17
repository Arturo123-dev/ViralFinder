using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ViralFinder.ViewModel
{
    public class InstaLoginModel : INotifyPropertyChanged
    {
        public InstaLoginModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;



        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this,new PropertyChangedEventArgs("Username") );
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }



        public Command BackCommand
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PopModalAsync(); });
            }
        }

        public Command InstaLogCommand
        {
            get { return new Command(LogInsta); }
        }

        //funzione per login insta
        public async void LogInsta()
        {

        }
    }
}
