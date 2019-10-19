using System.IO;
using System.Linq;

namespace BlogUploader
{
    public class DiskContentSource : IContentSource
    {
        private readonly string _basePath;

        public DiskContentSource(DiskContentSourceConfiguration config)
        {
            _basePath = config.BasePath;
        }

        public FileInfo[] GetFiles()
        {
            return Directory.GetFiles(_basePath, "*", SearchOption.AllDirectories)
                .Select(x => new FileInfo(x))
                .ToArray();
        }

        public string ToFullPath(string relativePath)
        {
            return Path.Combine(_basePath, relativePath);
        }

        public string ToRelativePath(string fullPath)
        {
            var relativePath = Path.GetRelativePath(_basePath, fullPath);

            return relativePath.Replace('\\', '/');
        }
    }
}
