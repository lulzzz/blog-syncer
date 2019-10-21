using System.IO;

namespace BlogUploader
{
    public interface ISourceFileInfo
    {
        string RelativePath { get; }
        
        Stream OpenRead();
    }
}
