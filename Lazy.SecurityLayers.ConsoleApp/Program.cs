using Lazy.SecurityLayers.Cryptography;
using Lazy.SecurityLayers.Cryptography.ServiceProvider;
using Lazy.SecurityLayers.Cryptography.ServiceProvider.Asymmetric.Base;
using Lazy.SecurityLayers.DependancyInjections;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Lazy.SecurityLayers.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var services = new ServiceCollection().AddCryptography().BuildServiceProvider();
                CryptoServiceProvider crypto = services.GetRequiredService<CryptoServiceProvider>();

                crypto[AsymmetricType.RSA].Generator.GenerateKeys(out string privateKey, out string publicKey);

                Console.WriteLine($"Private : {privateKey}");
                Console.WriteLine($"Public  : {publicKey}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
