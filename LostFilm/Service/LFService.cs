using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;



namespace Service.LostFilm
{
    class LFService:IService
    {
        public string Name { get { return "LostFilm"; } }
        public Uri Url { get { return new Uri("http://www.lostfilm.tv/"); } }
        public LFService()
        {
          
        }

        public async Task<IEnumerable<Show>> GetShows()
        {
            var doc = await Web.DownloadDocument(new Uri(Url, "serials.php"));
            var nodes = doc.DocumentNode.SelectNodes("//div[@class='mid']/div[@class='bb']/a");
            List<Show> result = new List<Show>();

            foreach (var node in nodes)
            {
                await new LFShow(node, this).GetSeasons();
            }
            return result;
        }

        public async Task<Show> GetShow()
        {
            var doc = new HtmlDocument();
            string t = await Web.Download(new Uri(Url, "serials.php"));
            doc.LoadHtml(t);
            return null;
        }

        public override string ToString()
        {
            return base.ToString() + "|" + Name;
        }
    }
}
