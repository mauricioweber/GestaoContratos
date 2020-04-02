using Microsoft.AspNetCore.Http;
using System.IO;

namespace GestaoContratos.Data
{
    public class FileUtils
    {
        internal static bool TrySaveFile(string prefix, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return false;
            }
            else
            {
                var directory = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{prefix}");

                Directory.CreateDirectory(directory);

                var path = Path.Combine(directory, file.FileName);
                var stream = new FileStream(path, FileMode.Create);
                file.CopyToAsync(stream);
            }

            return true;
        }

        internal static byte[] GetFile(string prefix, string fileName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{prefix}", fileName);

            return File.ReadAllBytes(path);
        }
    }
}
