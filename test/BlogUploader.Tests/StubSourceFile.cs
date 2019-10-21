using System;
using System.IO;

namespace BlogUploader.Tests
{
    public class StubSourceFile : ISourceFileInfo
    {
        public string RelativePath => throw new NotImplementedException();

        public Stream OpenRead()
        {
            throw new NotImplementedException();
        }
    }
}
