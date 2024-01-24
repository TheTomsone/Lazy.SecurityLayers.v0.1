using Lazy.SecurityLayers.Cryptography.Core.RSA;
using Lazy.SecurityLayers.Cryptography.ServiceProvider;
using Lazy.SecurityLayers.Cryptography.ServiceProvider.Asymmetric;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Lazy.SecurityLayers.DependancyInjections
{
    public static class CryptographyInjection
    {
        public static IServiceCollection AddCryptography(this IServiceCollection services)
        {
            services.AddScoped<RSACryptoServiceProvider>();

            services.AddScoped<RSADecryptorService>();
            services.AddScoped<RSAEncryptorService>();
            services.AddScoped<RSAGeneratorService>();

            services.AddScoped<IAsymmetricServiceProvider, RSAServiceProvider>();

            services.AddScoped<CryptoServiceProvider>();

            return services;
        }
    }

}
