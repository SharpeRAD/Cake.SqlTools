#region Using Statements
using System.IO;
using System.Text;

using Cake.Core.IO;
#endregion



namespace Cake.SqlTools
{
    internal static class FileExtensions
    {
        #region Methods
        internal static byte[] ReadBytes(this IFile file)
        {
            using (Stream stream = file.OpenRead())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }
        
        internal static string GetString(this byte[] bytes)
        {
             return Encoding.UTF8.GetString(bytes);
        }
        #endregion
    }
}