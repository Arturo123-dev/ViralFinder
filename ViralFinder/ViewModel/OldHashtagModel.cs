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

        private InstaClass insta = null;
        private Users user;
        private List<InstaSearchData> lista;
        public OldHashtagModel(Users user, InstaClass insta)
        {
            this.user = user;
            this.insta = insta;
            OnAppering();

            foreach (InstaSearchData hash in lista)
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

        protected async void OnAppering()
        {

            this.lista = await FirebaseHelper.GetInstaSearchData(user.Email);

        }



    }
}
