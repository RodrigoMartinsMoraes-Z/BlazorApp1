using BlazorInputFile;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlazorApp1.Scripts
{
    public class Auxiliar
    {
        public static async Task<string> ImagemEmByte(IFileListEntry arquivo)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                await arquivo.Data.CopyToAsync(memoryStream);
                bytes = memoryStream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }
    }
}
