using Lazy.SecurityLayers.Cryptography.ServiceProvider.Asymmetric.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.Cryptography.ServiceProvider
{
    public class CryptoServiceProvider
    {
        private readonly IDictionary<AsymmetricType, IAsymmetricServiceProvider> _asymmetrics;

        public CryptoServiceProvider(IEnumerable<IAsymmetricServiceProvider> asymmetrics)
        {
            _asymmetrics = new Dictionary<AsymmetricType, IAsymmetricServiceProvider>();

            foreach (var asym in asymmetrics)
                _asymmetrics.Add(asym.Type, asym);
        }

        public IAsymmetricServiceProvider this[AsymmetricType type] => _asymmetrics[type];
    }
}
