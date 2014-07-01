using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Service.LostFilm
{
    class LFShow:Show
    {
        internal LFShow(HtmlNode node, IService service):base(service)
        {
            Name = node.ChildNodes[0].InnerText;
            OriginalName = node.Element("span").InnerText;
            OriginalName = OriginalName.Substring(1, OriginalName.Length - 2);
            Url = new Uri(service.Url,node.Attributes["href"].Value);
        }

        public override string GetDescription()
        {
            throw new NotImplementedException();
        }

        public override string GetPoster()
        {
            throw new NotImplementedException();
        }

        public override async Task<IEnumerable<Season>> GetSeasons()
        {
            List<Season> result = new List<Season>();
            var doc = await Web.DownloadDocument(Url);
            var nodes = doc.DocumentNode.SelectNodes("//div[@class='mid']/div[2]/div[@class='content']//h2");
            if (nodes == null)
            {
                return result;
            }
            foreach(var node in nodes)
            {
                try
                {
                    result.Add(new LFSeason(node.ParentNode.ParentNode, Int32.Parse(node.InnerText.Substring(0, node.InnerText.IndexOf(' '))), doc, this));
                }
                catch {

                }
            }
            return result;
        }

        public override string ToString()
        {
            return base.ToString() + "|" + Name + "/" + OriginalName;
        }
    }
}
