using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _3._1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo outFile = new FileInfo(@"..\..\FileOut.txt");
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                // Encryption
                string text = File.ReadAllText(@"..\..\File.txt");
                byte[] encrypted = Encrypt(text, aes.Key, aes.IV);
                Compress(outFile, encrypted);
                // Decryption
                byte[] encryptedText = Decompress(outFile);
                text = Decrypt(encryptedText, aes.Key, aes.IV);
            }
            Console.ReadKey();
        }

        static byte[] Encrypt(string text, byte[] key, byte[] IV)
        {
            byte[] encrypted;
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                aes.IV = IV;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        static string Decrypt(byte[] text, byte[] key, byte[] IV)
        {
            string result;
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = key;
                aes.IV = IV;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream msDecrypt = new MemoryStream(text))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            result = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }

        public static void Compress(FileInfo file, byte[] text)
        {
            using (FileStream fs = file.Open(FileMode.OpenOrCreate))
            {
                using (GZipStream gzs = new GZipStream(fs, CompressionMode.Compress))
                {
                    gzs.Write(text, 0, text.Length);
                }
            }
        }

        public static byte[] Decompress(FileInfo file)
        {
            byte[] result;
            using (FileStream fs = file.Open(FileMode.Open))
            {
                using (GZipStream gzs = new GZipStream(fs, CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(gzs))
                    {
                        using (MemoryStream memStream = new MemoryStream())
                        {
                            reader.BaseStream.CopyTo(memStream);
                            result = memStream.ToArray();
                        }
                    }
                }
            }
            return result;
        }
    }
}