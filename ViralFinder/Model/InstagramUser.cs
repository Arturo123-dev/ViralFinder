using System;
namespace ViralFinder.Model
{
    public class InstagramUser
    {

        public string Username { get; set; }
        public string InstaPassword { get; set; }

        public InstagramUser(string user, string pwd)
        {
            this.Username = user;
            this.InstaPassword = pwd;
        }
    }
}
