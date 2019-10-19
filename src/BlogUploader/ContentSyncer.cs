using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BlogUploader
{
    public class ContentSyncer
    {
        private readonly IContentSource _source;
        private readonly ILogger _logger;
        private readonly IContentDestination _destination;

        public ContentSyncer(IContentSource source, IContentDestination destination, ILogger<ContentSyncer> logger)
        {
            _destination = destination;
            _source = source;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<string>> SynchronizeFilesAsync()
        {
            var processedFiles = new List<string>();
            var sourceFiles = _source.GetFiles();

            foreach (var file in sourceFiles)
            {
                string destinationPath = _source.ToRelativePath(file.FullName);
                var fileOnDestination = _destination.GetFile(destinationPath);

                if (fileOnDestination is null)
                {
                    // File is missing on destination
                    using var stream = file.OpenRead();

                    await _destination.WriteFileAsync(destinationPath, stream);

                    processedFiles.Add(destinationPath);
                }
                else if (fileOnDestination.ContentMD5 != MD5Hash(file.FullName))
                {
                    // File on destination is different
                    await _destination.DeleteFileAsync(destinationPath);

                    using var stream = file.OpenRead();
                    await _destination.WriteFileAsync(destinationPath, stream);

                    processedFiles.Add(destinationPath);
                }
                else
                {
                    _logger.LogInformation("File up to date: {file}", destinationPath);
                }
            }

            var destinationFiles = _destination.GetFiles();
            foreach (var file in destinationFiles)
            {
                if (!File.Exists(_source.ToFullPath(file.Path)))
                {
                    await _destination.DeleteFileAsync(file.Path);
                }
            }

            return processedFiles;
        }

        private string MD5Hash(string fullPath)
        {
            using var md5 = MD5.Create();
            using var file = File.Open(fullPath, FileMode.Open);

            return Convert.ToBase64String(md5.ComputeHash(file));
        }
    }
}
