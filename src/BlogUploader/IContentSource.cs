using System.Collections.Generic;

namespace BlogUploader
{
    public interface IContentSource
    {
        IReadOnlyCollection<ISourceFileInfo> GetFiles();

        bool HasFile(string relativePath);
    }
}
