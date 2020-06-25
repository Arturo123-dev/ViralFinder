using System;
using System.Collections.Generic;
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
               

                
            }
            




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
            
            return tot / i;
        }


        

        public async Task<List<int>> GetListaLike(String hashtag)
        {
            var tagFeed = await api.HashtagProcessor.GetTopHashtagMediaListAsync(hashtag, PaginationParameters.MaxPagesToLoad(1));
            var list = tagFeed.Value.Medias;

            
            List<int> ris = new List<int>();

            int n = 0;

            foreach(InstaMedia i in list)
            {
                n++;

                if (n < 8)
                {
                    ris.Add(i.LikesCount);
                }
                else
                    break;
                
            }
            return ris;
        }



        public async Task<List<int>> GetListaComm(String hashtag)
        {
            var tagFeed = await api.HashtagProcessor.GetTopHashtagMediaListAsync(hashtag, PaginationParameters.MaxPagesToLoad(1));
            var list = tagFeed.Value.Medias;
            

            List<int> ris = new List<int>();

            int n = 0;
          
            foreach (InstaMedia i in list)
            {
                n++;
                
                if (n < 8)
                {
                    ris.Add(int.Parse(i.CommentsCount));
                }
                else
                    break;

            }
        
            return ris;
        }


        public async Task<long> TempoMedio(string hashtag)
        {
            var tagFeed = await api.HashtagProcessor.GetTopHashtagMediaListAsync(hashtag, PaginationParameters.MaxPagesToLoad(1));
            var list = tagFeed.Value.Medias;

            int n = 0;
            DateTime ora;
            ora = DateTime.Now;
            TimeSpan Conf;
            int sum = 0;

            foreach(InstaMedia i in list)
            {

                n++;
                if (n < 8)
                {
                    Conf = ora - i.TakenAt;
                    sum += Conf.Hours;

                }
                else
                    break;

            }

            return sum / n;

        }


    }

}
