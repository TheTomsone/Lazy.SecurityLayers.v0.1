using Lazy.SecurityLayers.Cryptography.Core.Interfaces;
using Lazy.SecurityLayers.Cryptography.ServiceProvider.Asymmetric.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.ServiceProvider
{
    public interface IAsymmetricServiceProvider
    {
        AsymmetricType Type { get; }
        IAsymDecryptorService Decryptor { get; }
        IAsymEncryptorService Encryptor { get; }
        IAsymGeneratorService Generator { get; }
    }
}
