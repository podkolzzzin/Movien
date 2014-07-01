using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Service
{
    public class Web
    {
        private static WebClient _client = new WebClient();

        public static async Task<string> Download(Uri uri)
        {
            return await _client.DownloadStringTaskAsync(uri);
        }

        public static async Task<HtmlDocument> DownloadDocument(Uri uri)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(await Download(uri));
            return doc;
        }
    }
}
