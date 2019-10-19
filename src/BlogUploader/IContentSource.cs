using System.IO;

namespace BlogUploader
{
    public interface IContentSource
    {
        FileInfo[] GetFiles();

        string ToRelativePath(string fullPath);

        string ToFullPath(string relativePath);
    }
}
