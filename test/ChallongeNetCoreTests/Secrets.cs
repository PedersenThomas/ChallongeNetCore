using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallongeNetCoreTests
{
    public static class Secrets
    {
        public static string ChallongeUsername { get { return _configuration["challonge_username"]; } }
        public static string ChallongeApiKey { get { return _configuration["challonge_apikey"]; } }
        public static string ChallongeSubdomain { get { return _configuration["challonge_subdomain"]; } }

        private static IConfigurationRoot _configuration;

        static Secrets()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddUserSecrets();

            _configuration = configurationBuilder.Build();
        }
    }
}
