using Lazy.SecurityLayers.Cryptography.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.Asymmetric.AES
{
    public class AESGenerator(RandomNumberGenerator rng) : AbstractRandomNumberGeneratorService(rng), IAsymGeneratorService
    {
        public void GenerateKeys(out string privateKey, out string publicKey)
        {
            throw new NotImplementedException();
        }
    }
}
