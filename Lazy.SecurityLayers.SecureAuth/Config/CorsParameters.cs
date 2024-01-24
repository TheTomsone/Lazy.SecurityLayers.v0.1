using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy.SecurityLayers.DynamicCorsService.Config
{
    public class CorsParameters
    {
        public string[] AllowedOrigins { get; set; }
        public string[] DisallowedOrigins { get; set; }
        public string[] Methods { get; set; }
        public string[] Headers { get; set; }
        public bool AllowCredentials { get; set; }
    }
}
