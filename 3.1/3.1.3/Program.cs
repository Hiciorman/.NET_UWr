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
            string textFilePath = @"..\..\File.txt";

            FileInfo fileToCompress = new FileInfo(textFilePath);
            Compress(fileToCompress);


            string directoryPath = @"..\..\";

            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);

    

            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                Decompress(fileToDecompress);
            }

            Console.ReadKey();
        }

        public static void Compress(FileInfo fileToCompress)
        {
            FileStream originalFileStream = fileToCompress.OpenRead();
            FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz");

            GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress);

            originalFileStream.CopyTo(compressionStream);
            Console.WriteLine("Compressed {0} from {1} to {2} bytes.", fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString());
        }

        public static void Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }
    }
}
