using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.Interfaces
{
    public interface IAsymGeneratorService
    {
        public void GenerateKeys(out string privateKey, out string publicKey);
    }
}
