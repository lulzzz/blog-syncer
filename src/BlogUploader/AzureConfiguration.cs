using Microsoft.Extensions.Configuration;

namespace BlogUploader
{
    public class AzureConfiguration
    {
        public string ConnectionString { get; }

        public bool WhatIfMode { get; }

        public AzureConfiguration(IConfiguration configuration)
        {
            ConnectionString = configuration.GetValue<string>("AZURE_CONNECTIONSTRING");
            WhatIfMode = false;
        }
    }
}
