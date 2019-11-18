using BlazorInputFile;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace BlazorApp1.Scripts
{
    public class Auxiliar
    {
        public static async Task<string> ArquivoEmBase64(IFileListEntry arquivo)
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

        public static string GirarImagem(string imagemBase64)
        {
            byte[] imageBytes = Convert.FromBase64String(imagemBase64);
            MemoryStream imageStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            imageStream.Write(imageBytes, 0, imageBytes.Length);
            Image img = Image.FromStream(imageStream, true);
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);

            using MemoryStream ms = new MemoryStream();
            // Convert Image to byte[]
            img.Save(ms, ImageFormat.Jpeg);
            imageBytes = ms.ToArray();

            // Convert byte[] to Base64 String
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }
}
