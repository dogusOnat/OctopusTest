using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq; 
using OnatOctopusTest.Extensions;
using OnatOctopusTest.Core;
using System.Text.RegularExpressions;

namespace OnatOctopusTest.Services
{
    public class WebPageParserService : IWebPageParserService
    {
        public Dictionary<string, int> GetWordFrequency(string websiteURL)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");

            HtmlWeb web = new HtmlWeb();
            if (!(websiteURL.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || websiteURL.StartsWith("https://", StringComparison.OrdinalIgnoreCase)))
                websiteURL = "http://" + websiteURL;

            HtmlDocument doc = web.Load(websiteURL);

            string html = Worker.ClearHtml(doc.DocumentNode.OuterHtml);

            return html.Split(' ')
                      .Where(x => x != string.Empty && !Worker.filters.Contains(x.ToLower()) && r.IsMatch(x))
                       .GroupBy(x => x)
                       .ToDictionary(x => x.Key, x => x.Count()); 
        }
    }
}
