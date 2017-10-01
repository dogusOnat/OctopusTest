using Microsoft.Extensions.DependencyInjection;
using OnatOctopusTest.Core;
using OnatOctopusTest.Extensions;
using System;

using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace OnatOctopusTest.Models
{
    public class Word
    { 
        private string _text;
        private ICryptoService _cryptoService;

        public Word( ICryptoService cryptoService,  string text, int frequency, string wordType)
        {
            _cryptoService = cryptoService;
            _text = text; 

            Hashed = Encryption.Hash(_text);
            Frequency = frequency;
            WordType = wordType;
            Encrypted = _cryptoService.Encrypt(_text);
        }
        public Word( )
        { 
        }
       
        [Key]
        public string Hashed { get; set; }
        public int Frequency { get; set; }
        public string WordType { get; set; }
        public string Encrypted { get; set; }

       
    }
}
