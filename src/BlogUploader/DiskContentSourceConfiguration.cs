using Microsoft.Extensions.Configuration;

namespace BlogUploader
{
    public class DiskContentSourceConfiguration
    {
        public string BasePath { get; }

        public DiskContentSourceConfiguration(IConfiguration config)
        {
            BasePath = config.GetValue<string>("AZURE_CONTENT_PATH");
        }
    }
}
