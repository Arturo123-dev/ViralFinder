using System;
using System.ComponentModel;


using Xamarin.Forms;
using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.Classes;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Logger;
using InstagramApiSharp.Classes.Models;



namespace ViralFinder.ViewModel
{
    public class PageMasterModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //private readonly IInstaApi instaApi;
        public PageMasterModel()
        {

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

            
       

        }
    }
}
