using Lazy.SecurityLayers.Cryptography.Core.Interfaces;
using Lazy.SecurityLayers.Cryptography.Core.RSA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.ServiceProvider.Asymmetric.Base
{
    public class AbstractServiceProvider : IAsymmetricServiceProvider
    {
        private readonly AsymmetricType _type;
        private readonly IAsymDecryptorService _decryptor;
        private readonly IAsymEncryptorService _encryptor;
        private readonly IAsymGeneratorService _generator;

        protected AbstractServiceProvider(
            IAsymDecryptorService decryptor,
            IAsymEncryptorService encryptor,
            IAsymGeneratorService generator)
        {
            _decryptor = decryptor;
            _encryptor = encryptor;
            _generator = generator;
        }

        public AsymmetricType Type => _type;
        public IAsymDecryptorService Decryptor => _decryptor;
        public IAsymEncryptorService Encryptor => _encryptor;
        public IAsymGeneratorService Generator => _generator;

    }
}
