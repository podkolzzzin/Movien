using HtmlAgilityPack;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.LostFilm
{
    class LFEpisode:Episode
    {
        static int n = 0;
        internal LFEpisode(HtmlNode episodeNode, Season season)
        {
            try
            {

                Console.WriteLine(++n);

                Season = season;
                var node = episodeNode.SelectSingleNode("table/tr/td[@class='t_episode_title']//nobr");
                Name = node.Element("span").InnerText;
                Index = Int32.Parse(episodeNode.SelectSingleNode("table/tr/td[@class='t_episode_num']").InnerText.Clean());
                OriginalName = node.ChildNodes.Last().InnerText.UnWrapBrackets();
                ReleaseDate = DateTime.Parse(episodeNode.SelectSingleNode("table/tr[1]/td[2]/span[@class='micro']/span").InnerText.Clean());           
            }
            catch(Exception e)
            {

            }
        }

        public override void Download()
        {
            
        }
    }
}
