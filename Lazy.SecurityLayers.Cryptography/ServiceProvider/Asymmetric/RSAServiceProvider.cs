using Lazy.SecurityLayers.Cryptography.Core.Interfaces;
using Lazy.SecurityLayers.Cryptography.Core.RSA;
using Lazy.SecurityLayers.Cryptography.ServiceProvider.Asymmetric.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.ServiceProvider.Asymmetric
{
    public class RSAServiceProvider(RSADecryptorService decryptor, RSAEncryptorService encryptor, RSAGeneratorService generator) : AbstractServiceProvider(decryptor, encryptor, generator), IAsymmetricServiceProvider
    {
    }
}
