using OnatOctopusTest.Models;
using OnatOctopusTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnatOctopusTest.Core
{
    public interface IDataService
    { 
        IEnumerable<Word> GetAllWordsSorted(); 
        bool SaveWords(IEnumerable<WordVm> words);
    }
}
