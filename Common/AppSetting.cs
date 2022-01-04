using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Common
{
    public class AppSetting
    {
        public static void Init(IServiceCollection services)
        {
            _services = services;
        }

        private static IServiceCollection _services;
        private static IConfiguration _configuration;
        public static IConfiguration Configuration { 
            get
            {
                if (_configuration == null)
                {
                    var provider = _services.BuildServiceProvider();
                    _configuration = provider.GetService<IConfiguration>();
                }
                return _configuration;
            }
        }
    }
}
