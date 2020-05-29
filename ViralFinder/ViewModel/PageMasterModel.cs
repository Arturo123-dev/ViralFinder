using System;
using System.ComponentModel;


using Xamarin.Forms;
using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.Classes;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Logger;
using InstagramApiSharp.Classes.Models;
using ViralFinder.Classi;

namespace ViralFinder.ViewModel
{
    public class PageMasterModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private InstaClass insta = null;

        public PageMasterModel()
        {

        }

        public PageMasterModel(InstaClass insta)
        {
            this.insta = insta;
        }

        private string hashtag;
        public string Hashtag
        {
            get { return hashtag; }
            set
            {
                hashtag = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Hashtag"));
            }
        }

        private string dimensioni;
        public string Dimensioni
        {
            get { return dimensioni; }
            set
            {
                dimensioni = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Dimensioni"));
            }

        }


        public Command SearchCommand
        {
            get
            {
                return new Command(Search);
            }
        }


        private async void Search()
        {
            
            if (this.insta == null)
            {
                MessagingCenter.Subscribe<PageMasterModel, IInstaApi>(this.insta, "instaApi", (sender, arg) =>
                 {
                     this.insta =(InstaClass) arg;
                 });
            }

            if (insta.IsLogged())
            {
                Console.WriteLine("---------SONO LOGGATO---------");
            }
            else
            {
                Console.WriteLine("---------NON SONO STATI PASSATI DATI----------");
            }
       

        }
    }
}
