using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.Core.Asymmetric.AES
{
    public abstract class AbstractRandomNumberGeneratorService
    {
        private readonly RandomNumberGenerator _rng;

        protected AbstractRandomNumberGeneratorService(RandomNumberGenerator rng)
        {
            _rng = rng;
        }

        public RandomNumberGenerator RNG => _rng;
    }
}
