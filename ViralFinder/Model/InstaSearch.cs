using System;
using System.Collections.Generic;

namespace ViralFinder.Model
{
    public class InstaSearch
    {
        public List<InstaSearchData> data { get; set; }

        public InstaSearch()
        {
            data = new List<InstaSearchData>();
        }
    }
}
