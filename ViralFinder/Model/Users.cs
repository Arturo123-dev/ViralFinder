using System;
using System.Collections.Generic;
using Firebase.Auth;

namespace ViralFinder.Model
{
    public class Users
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public InstagramUser IgUser { get; set; }
        public InstaSearch InstaSearch { get; set; }

        public static implicit operator Users(User v)
        {
            throw new NotImplementedException();
        }
    }
}
