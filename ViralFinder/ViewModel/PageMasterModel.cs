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
        private readonly IInstaApi instaApi;
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

            Console.WriteLine("---------CERCA PREMUTO---------");

            var userSession = new UserSessionData
            {
                UserName = "black_cars_driver", 
                Password = "Fabrizio99"  
            };

            var api = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.All))
                .SetRequestDelay(RequestDelay.FromSeconds(0,1))
                .Build();
            

            var log = await api.LoginAsync(); 

            //Console.WriteLine(log.ToString());

            
            
            
            var tagFeed = await instaApi.FeedProcessor.GetTagFeedAsync("car", PaginationParameters.MaxPagesToLoad(5));


            if (tagFeed.Succeeded)
            {
                Console.WriteLine(
                    $"Tag feed items (in {tagFeed.Value.MediaItemsCount} pages) []: {tagFeed.Value.Medias.Count}");
                foreach (var media in tagFeed.Value.Medias)
                    Console.WriteLine(
                 $"{"tagFeed"} [{media.User.UserName}]: {media.Caption?.Text}, {media.Code}, likes: {media.LikesCount}, multipost: {media.IsMultiPost}");
            }
        
    


            //Console.WriteLine(tagFeed.ToString());


        }
    }
}
