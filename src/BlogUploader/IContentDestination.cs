using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BlogUploader
{
    public interface IContentDestination
    {
        IEnumerable<CloudFileInfo> GetFiles();

        CloudFileInfo GetFile(string path);

        Task WriteFileAsync(string path, Stream file);

        Task DeleteFileAsync(string path);
    }
}
