using System;
namespace ViralFinder.Model
{
    public class InstaSearchData
    {
        public string Hastag { get; set; }
        public long n { get; set; }
        public long like { get; set; }

        public InstaSearchData(string hastag, long n, long like)
        {
            this.Hastag = hastag;
            this.like = like;
            this.n = n;
        }
    }
}
