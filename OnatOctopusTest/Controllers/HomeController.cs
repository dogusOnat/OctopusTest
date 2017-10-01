using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnatOctopusTest.Core;
using OnatOctopusTest.ViewModels;

namespace OnatOctopusTest.Controllers
{
    public class HomeController : Controller
    {

        private IDataService _dataService;
        private IWebPageParserService _webPageParserService;
        public HomeController(IDataService dataService, IWebPageParserService webPageParserService)
        {
            _dataService = dataService;
            _webPageParserService = webPageParserService;
        }
        public IActionResult Index()
        {
            IndexVm vm = new IndexVm();

            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(IndexVm vm)
        {
            Dictionary<string, int> wordDict = null;

            if (!string.IsNullOrEmpty(vm.WebPageUrl))
                wordDict = _webPageParserService.GetWordFrequency(vm.WebPageUrl);

            if (wordDict != null && wordDict.Count > 0)
            {
                vm.Words = wordDict.Select(p => new WordVm()
                {
                    Frequency = p.Value,
                    Text = p.Key
                })
                    .OrderByDescending(p => p.Frequency)
                    .Take(100)
                    .ToList();

                vm.WordFrequencySum = vm.Words.Sum(w => w.Frequency);

                _dataService.SaveWords(vm.Words);

                //just to shuffle the words
                vm.Words = vm.Words.OrderBy(x => Guid.NewGuid()).ToList();
            }


            return View(vm);
        }

        public IActionResult Admin()
        {
            AdminVm vm = new AdminVm();

            vm.Words = _dataService.GetAllWordsSorted().Select(w => new WordVm() { Text = w.Decrypted, Frequency = w.Frequency }).ToList();

            return View(vm);
        }
    }
}
