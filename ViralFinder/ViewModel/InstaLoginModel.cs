using System;
using System.ComponentModel;
using Xamarin.Forms;
using ViralFinder.Classi;

using ViralFinder.Model;

using ViralFinder.View;

namespace ViralFinder.ViewModel
{
    public class InstaLoginModel : INotifyPropertyChanged
    {
        private Users user;
        public InstaLoginModel(Users user)
        {

            this.user = user;


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
            var insta = new InstaClass(username, password);
            await insta.InstagramLogin();


            if(await FirebaseHelper.SaveInstaData(username, password, user))
            {
                await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Login Fail", "", "OK");
            }

             await App.Current.MainPage.Navigation.PushModalAsync(new PageMaster(insta, user));

            //saveInstaData(username, password);

            if (insta.IsLogged())
                await App.Current.MainPage.Navigation.PushModalAsync(new PageMaster(insta,user));
            else
                await App.Current.MainPage.DisplayAlert("DATI INSTAGRAM ERRATI", "", "OK");

        }

       
    }
}
