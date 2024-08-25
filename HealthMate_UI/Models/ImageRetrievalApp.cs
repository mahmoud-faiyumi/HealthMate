using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace ImageRetrievalApp
{
    public class ImageUtils
    {
        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }
    }
}