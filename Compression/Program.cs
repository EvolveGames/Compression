using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] FileBytes = File.ReadAllBytes("test.txt");
            Console.WriteLine("Original: ");
            WriteBytes(FileBytes, 'O');
            FileBytes = CompressBytes(FileBytes);
            Console.WriteLine();
            Console.WriteLine("Compresed: ");
            WriteBytes(FileBytes, 'O');
            File.WriteAllBytes("data.dt", FileBytes);
            Console.ReadKey(true);
        }

        public static byte[] CompressBytes(byte[] input)
        {
            List<byte[]> compressedData = new List<byte[]>();
            for (int i = 0; i < input.Length; i++)
            {
                int count = 1;

                while (i + 1 < input.Length && input[i] == input[i + 1])
                {
                    count++;
                    i++;
                }
                byte[] compressedElement = new byte[2];
                compressedElement[0] = (byte)count;
                compressedElement[1] = input[i];

                compressedData.Add(compressedElement);
            }

            byte[] output = new byte[compressedData.Count * 2];

            for (int i = 0; i < compressedData.Count; i++)
            {
                Array.Copy(compressedData[i], 0, output, i * 2, 2);
            }

            return output;
        }

        public static void WriteBytes(byte[] input, char view)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == Encoding.Default.GetBytes(view.ToString())[0])
                {
                    ConsoleColor InitColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{input[i]} ");
                    Console.ForegroundColor = InitColor;
                }
                else Console.Write($"{input[i]} ");
            }

        }

        
    }
}
