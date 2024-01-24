using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.RSA
{
    public abstract class AbstractRSAService
    {
        protected readonly RSACryptoServiceProvider _rsa;

        protected AbstractRSAService(RSACryptoServiceProvider rsa)
        {
            _rsa = rsa;
        }
    }
}
