using Lazy.SecurityLayers.Cryptography.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.RSA
{
    public class RSADecryptorService(RSACryptoServiceProvider rsa) : AbstractRSAService(rsa), IAsymDecryptorService
    {
        public string DecryptData(byte[] encryptedData, string privateKey)
        {
            _rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
            byte[] decryptedData = _rsa.Decrypt(encryptedData, true);

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
