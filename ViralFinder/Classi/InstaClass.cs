using System;
using System.Threading.Tasks;
using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
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








    }

}
