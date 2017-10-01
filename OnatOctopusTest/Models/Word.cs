using OnatOctopusTest.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnatOctopusTest.Models
{
    public class Word
    { 
        private string _text;

        public Word(  string text, int frequency, string wordType)
        {
            _text = text; 

            Hashed = Encryption.Hash(_text);
            Frequency = frequency;
            WordType = wordType;
            Encrypted = Encryption.EncryptString( _text);
        }
        public Word()
        {
        }
        public virtual string Decrypted
        {
            get
            {
                return Encryption.DecryptString( Encrypted);
            }
        }
         
        [Key]
        public string Hashed { get; set; }
        public int Frequency { get; set; }
        public string WordType { get; set; }
        public string Encrypted { get; set; }
       
       
    }
}
