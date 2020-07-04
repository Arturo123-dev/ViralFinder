using System;
using System.ComponentModel;


using Xamarin.Forms;
using InstagramApiSharp;
using InstagramApiSharp.API;
using InstagramApiSharp.Classes;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Logger;
using InstagramApiSharp.Classes.Models;
using ViralFinder.Classi;
using ViralFinder.Model;
using Microcharts;
using System.Collections.Generic;
using SkiaSharp;
using System.Threading.Tasks;

namespace ViralFinder.ViewModel
{
    public class PageMasterModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private InstaClass insta = null;
        private Users user;

        private Microcharts.Forms.ChartView datiChart;
        private List<Microcharts.Entry> entries;

        private Microcharts.Forms.ChartView datiChartComments;
        private List<Microcharts.Entry> entriesComments;

        public PageMasterModel()
        {

        }

        public PageMasterModel(InstaClass insta, Users user, Microcharts.Forms.ChartView chart, Microcharts.Forms.ChartView commentChart)
        {
            this.user = user;
            this.insta = insta;
            this.datiChart = chart;
            this.datiChartComments = commentChart;

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

        private string npost;
        public string Npost
        {
            get { return npost; }
            set
            {
                npost = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Npost"));
            }
        }


        private string avgLike;
        public string AvgLike
        {
            get { return avgLike; }
            set
            {
                avgLike = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AvgLike"));
            }
        }

        private string avgComm;
        public string AvgComm
        {
            get { return avgComm; }
            set
            {
                avgComm = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AvgComm"));
            }
        }

        private string punteggio;
        public string Punteggio
        {
            get { return punteggio; }
            set
            {
                punteggio = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Punteggio"));
            }
        }


        public Command SearchCommand
        {
            get
            {
                return new Command(Search);
            }
        }


        private async Task<List<Microcharts.Entry>> CreateLikeEntries()
        {
            List<int> lista = await insta.GetListaLike(hashtag);

            entries = new List<Microcharts.Entry>();

            int a = 0;
            foreach (int i in lista)
            {
                a++;
                entries.Add(
                    new Microcharts.Entry(i)
                    {
                        Color = SKColor.Parse("#008080"),
                        ValueLabel = i.ToString(),
                        Label = "#" + a,



                    });
            }



            return entries;
        }

        private async Task<List<Microcharts.Entry>> CreateCommentsEntries()
        {
            List<int> lista = await insta.GetListaComm(hashtag);

            entriesComments = new List<Microcharts.Entry>();

            int a = 0;
            foreach (int i in lista)
            {
                a++;
                entriesComments.Add(
                    new Microcharts.Entry(i)
                    {
                        Color = SKColor.Parse("#008080"),
                        ValueLabel = i.ToString(),
                        Label = "#" + a,



                    });
            }



            return entriesComments;
        }


        private async void Search()
        {
            // passa qui l'hashtag per salvarlo in quelli cercati precedentemente da visualizzare su "OldHashtag"
            // da salvare con:
            // 1) hasthag
            // 2) N° post
            // 3) N° Like medio



            long n = await insta.GetHashtagNumber(hashtag);
            Npost = "N° POST #" + hashtag + ": " + n.ToString();
            
          
            entries = await CreateLikeEntries();
            datiChart.Chart = new LineChart { Entries = entries };
            datiChart.Chart.LabelTextSize = 25;

            long like = await insta.GetTopHashtagAvgLike(hashtag);
            AvgLike = "N° MEDIO LIKE #" + hashtag + ": " + like.ToString();

            entriesComments = await CreateCommentsEntries();
            datiChartComments.Chart = new LineChart { Entries = entriesComments };
            datiChartComments.Chart.LabelTextSize = 25;

            long comm = await insta.GetTopHashtagCommentAvg(hashtag);
            AvgComm = "N° MEDIO COMMENTI #" + hashtag + ": " + comm.ToString();

            long tempo = await insta.TempoMedio(hashtag);
            Punteggio = (like / comm / tempo).ToString();

            await FirebaseHelper.SaveInstaSearch(user.Email, hashtag, n, like);
        }
    }
}
