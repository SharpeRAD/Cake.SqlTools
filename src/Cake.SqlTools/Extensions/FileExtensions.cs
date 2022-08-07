using System.IO;
using System.Text;

using Cake.Core.IO;

namespace Cake.SqlTools
{
    internal static class FileExtensions
    {
        internal static byte[] ReadBytes(this IFile file)
        {
            using var stream = file.OpenRead();
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            return ms.ToArray();
        }

        internal static string GetString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
