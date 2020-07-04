using System;
using System.Collections.Generic;

namespace ViralFinder.Model
{
    public class Users
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public InstagramUser IgUser { get; set; }
        public InstaSearch InstaSearch { get; set; }
    }
}
