using Lazy.SecurityLayers.Cryptography.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.RSA
{
    public class RSAGeneratorService(RSACryptoServiceProvider rsa) : AbstractRSAService(rsa), IAsymGeneratorService
    {
        public void GenerateKeys(out string privateKey, out string publicKey)
        {
            privateKey = Convert.ToBase64String(_rsa.ExportRSAPrivateKey());
            publicKey = Convert.ToBase64String(_rsa.ExportRSAPublicKey());
        }
    }
}
