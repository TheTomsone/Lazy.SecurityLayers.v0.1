using Lazy.SecurityLayers.Cryptography.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.RSA
{
    public class RSAEncryptorService(RSACryptoServiceProvider rsa) : AbstractRSAService(rsa), IAsymEncryptorService
    {
        public byte[] EncryptData(string data, string publicKey)
        {
            _rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);

            return _rsa.Encrypt(dataToEncrypt, true);
        }
    }
}
