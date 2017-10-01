using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnatOctopusTest.Extensions
{
    public static class Worker
    {
        public static string ClearHtml(string htmlString)
        {
            string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
            htmlString = htmlString.Replace("&nbsp;", string.Empty);

            return htmlString;
        }
        public static string GetTagClass(int category, int articles)
        {
            var result = (category * 100) / articles;

            //if (result <= 1)
            //    return "tag1";
            //if (result <= 4)
            //    return "tag2";
            //if (result <= 8)
            //    return "tag3";
            //if (result <= 12)
            //    return "tag4";
            //if (result <= 18)
            //    return "tag5";
            //if (result <= 30)
            //    return "tag6";
            //return result <= 50 ? "tag7" : "";

            if (result <= 1)
                return "0.5em";
            if (result <= 4)
                return "1em";
            if (result <= 8)
                return "2em";
            if (result <= 12)
                return "3em";
            if (result <= 18)
                return "4em";
            if (result <= 30)
                return "5em";
            return result <= 50 ? "6em" : "";
        }
    }
}
