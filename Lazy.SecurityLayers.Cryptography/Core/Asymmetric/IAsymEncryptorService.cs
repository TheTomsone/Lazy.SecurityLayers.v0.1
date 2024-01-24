using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.Interfaces
{
    public interface IAsymEncryptorService
    {
        public byte[] EncryptData(string data, string publicKey);
    }
}
