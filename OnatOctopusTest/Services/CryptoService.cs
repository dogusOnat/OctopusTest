using Microsoft.AspNetCore.DataProtection;
using OnatOctopusTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnatOctopusTest.Services
{
    public class CryptoService : ICryptoService
    { 
            IDataProtector _iPro;

            // the 'provider' parameter is provided by DI
            public CryptoService(IDataProtectionProvider provider)
            {
                _iPro = provider.CreateProtector("ProClass");
            }

        public string Encrypt(string input)
        {
            return _iPro.Protect(input);
        }

        public string Decrypt(string input)
        {
            return _iPro.Unprotect(input);
        }
       
         
    }
}
