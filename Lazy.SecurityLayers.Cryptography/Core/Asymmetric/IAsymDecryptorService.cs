using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.Interfaces
{
    public interface IAsymDecryptorService
    {
        public string DecryptData(byte[] encryptedData, string privateKey);
    }
}
