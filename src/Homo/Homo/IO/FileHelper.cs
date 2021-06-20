using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Homo.IO
{
    public static class FileHelper
    {
        public static void DeleteIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static string GetExtension( string extension)
        {
            extension.CheckNotNull(nameof(extension));

            var lastDotIndex = extension.LastIndexOf('.');

            if (lastDotIndex < 0)
            {
                return null;
            }

            return extension.Substring(lastDotIndex + 1);
        }

        public static async Task<string> ReadAllTextAsync(string path)
        {
            using (var reader = File.OpenText(path))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task<byte[]> ReadAllBytesAsync(string path)
        {
            using (var stream = File.Open(path, FileMode.Open))
            {
                var result = new byte[stream.Length];
                await stream.ReadAsync(result, 0, (int)stream.Length);

                return result;
            }
        }

        public static async Task<string[]> ReadAllLinesAsync(string path,
            Encoding encoding = null,
            FileMode fileMode = FileMode.Open,
            FileAccess fileAccess = FileAccess.Read,
            FileShare fileShare = FileShare.Read,
            int bufferSize = 4096,
            FileOptions fileOptions = FileOptions.Asynchronous | FileOptions.SequentialScan)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            var lines = new List<string>();

            using (var stream = new FileStream(
                path,
                fileMode,
                fileAccess,
                fileShare,
                bufferSize,
                fileOptions))
            {
                using (var reader = new StreamReader(stream, encoding))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }

            return lines.ToArray();
        }
    }
}
