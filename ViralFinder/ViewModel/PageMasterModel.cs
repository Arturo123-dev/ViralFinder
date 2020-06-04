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
using ViralFinder.Model;

namespace ViralFinder.ViewModel
{
    public class PageMasterModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private InstaClass insta = null;
        private Users user;

        public PageMasterModel()
        {

        }

        public PageMasterModel(InstaClass insta, Users user)
        {
            this.user = user;
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

        


        public Command SearchCommand
        {
            get
            {
                return new Command(Search);
            }
        }


        private async void Search()
        {
<<<<<<< Updated upstream
            
            
=======
>>>>>>> Stashed changes

            // var n = insta.GetTopHashtagAvgLike(hashtag);
          


        }
    }
}
