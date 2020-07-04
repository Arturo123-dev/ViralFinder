using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using ViralFinder.Classi;
using ViralFinder.Model;

namespace ViralFinder.ViewModel
{
    public class FirebaseHelper
    {
        public static FirebaseClient firebase = new FirebaseClient("https://viralfinder-ba340.firebaseio.com/");

        //Read All
        public static async Task<List<Users>> GetAllUser()
        {
            try
            {
                var userlist = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Select(item =>
                new Users
                {
                    Email = item.Object.Email,
                    Password = item.Object.Password,
                }).ToList();
                return userlist;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read 
        public static async Task<Users> GetUser(string email)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("Users")
                .OnceAsync<Users>();
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Inser a user
        public static async Task<bool> AddUser(string email, string password)
        {
            try
            {


                await firebase
                .Child("Users")
                .PostAsync(new Users() { Email = email, Password = password});
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update 
        public static async Task<bool> UpdateUser(string email, string password)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() { Email = email, Password = password });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User
        public static async Task<bool> DeleteUser(string email)
        {
            try
            {


                var toDeletePerson = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }


        public static async Task<bool> ExistInstaAccount(string email)
        {
            try
            {
                var userlist = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Select(item =>
                new Users
                {
                    Email = item.Object.Email,
                    IgUser = item.Object.IgUser
                }).ToList();

                var ig = userlist.Where(a => a.Email == email).FirstOrDefault();

                if(ig.IgUser != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }


        public static async Task<InstagramUser> GetInstaUser(String email)
        {
            try
            {
                var userlist = (await firebase
                 .Child("Users")
                 .OnceAsync<Users>()).Select(item =>
                 new Users
                 {
                     Email = item.Object.Email,
                     IgUser = item.Object.IgUser
                 }).ToList();

                var ig = userlist.Where(a => a.Email == email).FirstOrDefault();
                return ig.IgUser;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        public static async Task<bool> SaveInstaData(string username, string password, Users user)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == user.Email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() { Email = user.Email, Password = user.Password, IgUser = new InstagramUser(username, password)});
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<bool> SaveInstaSearch(string email, string hashtag, long n, long like)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();

                List<InstaSearchData> instaData;

                if (toUpdateUser.Object.InstaSearch == null)
                {
                    instaData = new List<InstaSearchData>();
                    instaData.Add(new InstaSearchData(hashtag, n, like));
                }
                else
                {
                    instaData = toUpdateUser.Object.InstaSearch.data;
                    instaData.Add(new InstaSearchData(hashtag, n, like));
                }

                

                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() {
                    Email = toUpdateUser.Object.Email,
                    Password = toUpdateUser.Object.Password,
                    IgUser = new InstagramUser(toUpdateUser.Object.IgUser.Username, toUpdateUser.Object.IgUser.InstaPassword),
                    InstaSearch = new InstaSearch() {
                        data = instaData,
                    },
                });
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        public static async Task<List<InstaSearchData>> GetInstaSearchData(String email)
        {
            try
            {
                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();

                return toUpdateUser.Object.InstaSearch.data;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

    }
}
