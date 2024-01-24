using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.SecureAuth.Config
{
    public class TokenParameters(string secretKey, string issuer, string audience)
    {
        public required string SecretKey { get; set; } = secretKey;
        public required string Issuer { get; set; } = issuer;
        public required string Audience { get; set; } = audience;
    }
}
