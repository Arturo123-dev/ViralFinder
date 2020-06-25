using System;
using System.ComponentModel;
using ViralFinder.Classi;
using ViralFinder.Model;
using ViralFinder.View;
using Xamarin.Forms;


namespace ViralFinder.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel()
        {

        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
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

        private bool active;
        public bool Active
        {
            get { return active; }
            set
            {
                active = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Active"));

            }
        }

        

        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }
        public Command SignUp
        {
            get
            {
                return new Command(() => { App.Current.MainPage.Navigation.PushAsync(new XF_SignUpPage()); });
            }
        }



        private async void Login()
        {
            //null or empty field validation, check weather email and password is null or empty

            Active = true;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
                await App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            else
            {
                //call GetUser function which we define in Firebase helper class
                var user = await FirebaseHelper.GetUser(Email);
                //firebase return null valuse if user data not found in database
                if (user != null)
                    if (Email == user.Email && Password == user.Password)
                    {
                        
                        //Navigate to Wellcom page after successfuly login
                        //pass user email to welcom page

                        var esisteInsta = await FirebaseHelper.ExistInstaAccount(Email); //non funziona

                        if (esisteInsta) //verifica l' esitenza di InstaUser
                        {
                            var ig = await FirebaseHelper.GetInstaUser(Email); //non so ancora se funziona
                            var insta = new InstaClass(ig.Username, ig.InstaPassword);
                            await insta.InstagramLogin();
                            Active = false;
                            await App.Current.MainPage.Navigation.PushModalAsync(new PageMaster(insta, user));
                        }
                        else
                        {
                            Active = false;
                            await App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                            await App.Current.MainPage.Navigation.PushModalAsync(new PageMaster(user));
                        }

                    }
                    else
                    {
                        Active = false;
                        await App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
                    }

                else
                {
                    Active = false;
                    await App.Current.MainPage.DisplayAlert("Login Fail", "User not found", "OK");
                }
                    
            }
        }
    }
}
