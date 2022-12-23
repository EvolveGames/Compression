using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compression
{
    public static class CompressEngine
    {
        public static byte[] BasicCompressBytes(byte[] input)
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

        public static byte[] BasicDecompressBytes(byte[] input)
        {
            byte[] output = new byte[0];
            for(int i = 0; i < input.Length / 2; i++)
            {
                for(int j = 0; j < (int)input[i * 2]; j++)
                {
                    Array.Resize(ref output, output.Length + 1);
                    output[output.Length - 1] = input[i * 2 + 1];
                }
            }
            return output;
        }

        public static void WriteBytes(byte[] input, char[] view, ConsoleColor[] colors)
        {
            for (int i = 0; i < input.Length; i++)
            {
                bool can = true;
                for (int j = 0; j < view.Length; j++)
                {
                    if (input[i] == Encoding.Default.GetBytes(view[j].ToString())[0])
                    {
                        ConsoleColor InitColor = Console.ForegroundColor;
                        Console.ForegroundColor = colors[j];
                        Console.Write($"{input[i]} ");
                        Console.ForegroundColor = InitColor;
                        j = view.Length;
                        can = false;
                    }
                }
                if (can) Console.Write($"{input[i]} ");
            }
        }
    }
}
