using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HealthMate_UI
{
    public class EncryptionService
    {
        private readonly Aes aes;

        public EncryptionService(string encryptionKey, string initializationVector)
        {
            aes = Aes.Create();
            aes.Key = Convert.FromBase64String(encryptionKey);
            aes.IV = Convert.FromBase64String(initializationVector);
        }

        public string Encrypt(string plainText)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    var bytesToEncrypt = Encoding.UTF8.GetBytes(plainText);

                    // Encrypt the data and write it to the crypto stream
                    cryptoStream.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();
                }
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }

        public string Decrypt(string encryptedText)
        {
            using (var memoryStream = new MemoryStream(Convert.FromBase64String(encryptedText)))
            {
                using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    var decryptedBytes = new List<byte>();
                    int data;
                    while ((data = cryptoStream.ReadByte()) != -1)
                    {
                        decryptedBytes.Add((byte)data);
                    }

                    return Encoding.UTF8.GetString(decryptedBytes.ToArray());
                }
            }
        }
    }
}