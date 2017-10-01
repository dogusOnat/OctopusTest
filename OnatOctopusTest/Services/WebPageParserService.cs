using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq; 
using OnatOctopusTest.Extensions;
using OnatOctopusTest.Core;

namespace OnatOctopusTest.Services
{
    public class WebPageParserService : IWebPageParserService
    {
        public Dictionary<string, int> GetWordFrequency(string websiteURL)
        {
            HtmlWeb web = new HtmlWeb();
            if (!(websiteURL.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || websiteURL.StartsWith("https://", StringComparison.OrdinalIgnoreCase)))
                websiteURL = "http://" + websiteURL;

            HtmlDocument doc = web.Load(websiteURL);

            string html = Worker.ClearHtml(doc.DocumentNode.OuterHtml);

            return html.Split(' ')
                       .Where(x => x != string.Empty)
                       .GroupBy(x => x)
                       .ToDictionary(x => x.Key, x => x.Count()); 
        }
    }
}
