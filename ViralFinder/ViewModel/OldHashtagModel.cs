using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Firebase.Auth;
using ViralFinder.Classi;
using ViralFinder.Model;

namespace ViralFinder.ViewModel
{
    public class OldHashtagModel
    {
        private ObservableCollection<string> hashtags;

        private InstaClass insta = null;
        private Users user;
        private List<InstaSearchData> lista;
        public OldHashtagModel(Users user, InstaClass insta, List<InstaSearchData> data)
        {
            this.user = user;
            this.insta = insta;
            this.lista = data;
            Hashtagss();
        }

        public void Hashtagss()
        {

            hashtags = new ObservableCollection<string>();

            foreach (InstaSearchData hash in this.lista)
            {
                Hashtags.Add(hash.Hastag);
            }

        }


        public ObservableCollection<string> Hashtags
        {
            get { return hashtags; }
            set
            {
                hashtags = value;
            }
        }


    }
}
