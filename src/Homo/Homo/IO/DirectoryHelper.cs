using System.IO;

namespace Homo.IO
{
    public static class DirectoryHelper
    {

        public static void CreateIfNotExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public static void CreateIfNotExists(DirectoryInfo directory)
        {
            if (!directory.Exists)
            {
                directory.Create();
            }
        }

        public static void DeleteIfExists(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory);
            }
        }

        public static void DeleteIfExists(string directory, bool recursive)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, recursive);
            }
        }
    }
}
