using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnatOctopusTest.Core
{
    public interface IWebPageParserService
    {
        Dictionary<string, int> GetWordFrequency(string websiteURL);
    }
}
