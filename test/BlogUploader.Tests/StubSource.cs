using System;
using System.Collections.Generic;

namespace BlogUploader.Tests
{
    public class StubSource : IContentSource
    {
        public IReadOnlyCollection<StubSourceFile> GetFiles()
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string relativePath)
        {
            throw new NotImplementedException();
        }

        IReadOnlyCollection<ISourceFileInfo> IContentSource.GetFiles()
        {
            return GetFiles();
        }
    }
}
