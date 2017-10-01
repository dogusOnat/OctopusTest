using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnatOctopusTest.ViewModels
{
    public class WordVm
    {
        public string Text { get; set; }
        public int Frequency { get; set; }
        public string WordType { get; set; }
         
    }

    public class IndexVm
    {
        public string WebPageUrl { get; set; }
        public List<WordVm> Words { get; set; }
        public int WordFrequencySum { get; set; }
    }

    public class AdminVm
    { 
        public List<WordVm> Words { get; set; }
    }
}
