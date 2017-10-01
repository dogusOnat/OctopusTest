using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnatOctopusTest.Core
{
    public interface ICryptoService
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }
}
