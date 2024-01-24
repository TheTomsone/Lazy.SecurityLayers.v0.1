using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.Asymmetric.AES
{
    public abstract class AbstractAESCryptoService
    {
        private readonly AesGcm _aes;

        protected AbstractAESCryptoService(AesGcm aes)
        {
            _aes = aes;
        }

        public AesGcm AES => _aes;
    }
}
