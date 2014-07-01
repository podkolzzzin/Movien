using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.LostFilm
{
    class LFSeason:Season
    {
        
        internal LFSeason(HtmlNode seasonNode,int index, HtmlDocument doc, Show show)
        {
            Show = show;
            Index = index;
            var nodes = doc.DocumentNode.SelectNodes("//div[@class='mid']/div[2]/div");
            var episodes = new List<Episode>();

            for(var episodeNode = seasonNode.NextSibling;episodeNode != null && !_isSeasonNode(episodeNode); episodeNode = episodeNode.NextSibling)
            {
                if (episodeNode.InnerHtml.Clean().Length == 0) continue;
                if (!_isFullSeasonNode(episodeNode))
                    episodes.Add(new LFEpisode(episodeNode, this));
                else
                    _saveSeasonData(episodeNode);

            }
        }

        private bool _isSeasonNode(HtmlNode node)
        {
            try
            {
                if (node.Attributes["class"] == null) return false;
                return node.Attributes["class"].Value == "content";
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private void _saveSeasonData(HtmlNode node)
        {
            
        }

        private bool _isFullSeasonNode(HtmlNode node)
        {
            var lbl = node.SelectSingleNode("table/tr[1]/td[1]/label");
            if(lbl != null)
                return lbl.InnerText.Clean() == "С";
            return false;

        }

        public IEnumerable<Episode> GetEpisodes()
        {
            throw new NotImplementedException();
        }
    }
}
