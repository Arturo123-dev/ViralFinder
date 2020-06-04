using System;
using System.Threading.Tasks;
using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;

namespace ViralFinder.Classi
{
    public class InstaClass
    {

        public UserSessionData UserData;
        private static IInstaApi api;



        public InstaClass(String username, String pwd)
        {
            UserData = new UserSessionData
            {
                UserName = username,
                Password = pwd
            };

            api = InstaApiBuilder.CreateBuilder()
                  .SetUser(UserData)
                  .UseLogger(new DebugLogger(LogLevel.All))
                  .SetRequestDelay(RequestDelay.FromSeconds(0, 1))
                  .Build();
        }


        public Boolean IsLogged()
        {
            return api.IsUserAuthenticated;

        }


        public async Task InstagramLogin()
        {

            

            if (!api.IsUserAuthenticated)
            {
                
                await api.SendRequestsBeforeLoginAsync();
                await Task.Delay(2000);
                var logResult = await api.LoginAsync();

                if (logResult.Succeeded)
                {
                    Console.WriteLine("----- LOGIN RIUSCITO -----");
                    await api.SendRequestsAfterLoginAsync();
                    await App.Current.MainPage.DisplayAlert("LOGIN RIUSCITO", "goditi l'app", "OK");
                    
                }
                else
                {
                    Console.WriteLine("------ LOGIN FALLITO ------");
                    await App.Current.MainPage.DisplayAlert("LOGIN FALLITO", "ricontrolla i dati", "OK");
                }

            }
            else
            {
                Console.WriteLine("LOGIN GIA' EFFETTUATO", "goditi l'app", "OK");
            }

        }


        public async Task<long> GetHashtagNumber(String hashtag)
        {

            var tagfeed = await api.HashtagProcessor.GetHashtagInfoAsync(hashtag);
            Console.WriteLine("-------------" + tagfeed.Value.MediaCount + "-------------");
            return tagfeed.Value.MediaCount;

        }


        public async Task<long> GetTopHashtagAvgLike(String hashtag)
        {

            var tagfeed = await api.HashtagProcessor.GetTopHashtagMediaListAsync(hashtag, PaginationParameters.MaxPagesToLoad(2) );
            var mediaList = tagfeed.Value.Medias;
            Console.WriteLine("--------- NUMERO TOP MEDIA: " + mediaList.Count);

            int i = 0;
            int avg = 0;
            foreach(InstaMedia media in mediaList)
            {
                i++;
                avg = avg + media.LikesCount;
               

                Console.WriteLine("------------" + media.LikesCount);
            }
            Console.WriteLine("------------" + avg/i + "--------------");




            return avg / i;

        }

        public async Task<long> GetTopHashtagCommentAvg(String hashtag)
        {
            var tagfeed = await api.HashtagProcessor.GetTopHashtagMediaListAsync(hashtag, PaginationParameters.MaxPagesToLoad(2));
            var mediaList = tagfeed.Value.Medias;

            int i = 0;
            int tot = 0;

            foreach (InstaMedia media in mediaList)
            {
                i++;
                tot = tot + int.Parse(media.CommentsCount);
               
            }
            Console.WriteLine("----------" + tot / i + "---------");
            return tot / i;
        }



        public async Task ig(String hashtag)
        {
            var tagFeed = await api.HashtagProcessor.GetRecentHashtagMediaListAsync(hashtag, PaginationParameters.MaxPagesToLoad(2));
            var list = tagFeed.Value.Medias;
            foreach(InstaMedia i in list)
            {
                //
            }
        }

    }

}
