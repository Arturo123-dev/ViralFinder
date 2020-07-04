using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Firebase.Auth;
using ViralFinder.Classi;
using ViralFinder.Model;

namespace ViralFinder.ViewModel
{
    public class OldHashtagModel
    {

        private InstaClass insta = null;
        private Users user;
        public OldHashtagModel(Users user, InstaClass insta)
        {
            this.user = user;
            this.insta = insta;
            List<InstaSearchData> lista = new List<InstaSearchData>;  // funzione di christian;

            foreach(InstaSearchData hash in lista)
            {
                Hashtags.Add(hash);
            }

        }

        private ObservableCollection<InstaSearchData> hashtags;
        public ObservableCollection<InstaSearchData> Hashtags
        {
            get { return hashtags; }
            set
            {
                hashtags = value;
            }
        }



    }
}
