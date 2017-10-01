using OnatOctopusTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnatOctopusTest.Models;
using DataAccessMySqlProvider;
using OnatOctopusTest.Extensions;
using OnatOctopusTest.ViewModels;

namespace OnatOctopusTest.Services
{
    public class DataService : IDataService
    {
        private DomainModelMySqlContext _dbContext;
     

        public DataService(  DomainModelMySqlContext dbContext)
        { 

            _dbContext = dbContext;
        }

        public IEnumerable<Word> GetAllWordsSorted()
        {
            return _dbContext.Words.OrderByDescending(x => x.Frequency).ToList();
        }
         


        public bool SaveWords(IEnumerable<WordVm> words)
        {
            foreach (WordVm item in words)
            {
                Word tmpWord = GetWord(item.Text);

                if (tmpWord == null)
                {
                    tmpWord = new Word(item.Text, item.Frequency, item.WordType);
                    _dbContext.Words.Add(tmpWord);
                }
                else
                    tmpWord.Frequency += item.Frequency; 
            }

            _dbContext.SaveChanges();

            return true;
        }

        private Word GetWord(string word)
        {
            string hashedWord = Encryption.Hash(word);

            return _dbContext.Words.FirstOrDefault(w => w.Hashed == hashedWord);
        }
    }
}
