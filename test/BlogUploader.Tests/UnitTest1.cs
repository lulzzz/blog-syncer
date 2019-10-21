using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace BlogUploader.Tests
{
    public class StubDestination : IContentDestination
    {
        public Task DeleteFileAsync(string path)
        {
            throw new System.NotImplementedException();
        }

        public CloudFileInfo GetFile(string path)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CloudFileInfo> GetFiles()
        {
            throw new System.NotImplementedException();
        }

        public Task WriteFileAsync(string path, Stream file)
        {
            throw new System.NotImplementedException();
        }
    }

    public class ContentSyncerFacts
    {
        private readonly ILogger<ContentSyncer> _logger;
        private readonly StubSource _source;

        public ContentSyncerFacts(ITestOutputHelper outputHelper)
        {
            _logger = new XunitLogger<ContentSyncer>(outputHelper);
            _source = new StubSource();
            _destination = new StubDestination();
        }

        [Fact]
        public void Test1()
        {
            new ContentSyncer(, , _logger);
        }
    }
}
