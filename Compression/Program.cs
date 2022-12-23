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

            for (int i = 0; i < FileBytes.Length; i++)
            {
                if (FileBytes[i] == Encoding.Default.GetBytes("O")[0])
                {
                    ConsoleColor InitColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{FileBytes[i]} ");
                    Console.ForegroundColor = InitColor;
                }
                else Console.Write($"{FileBytes[i]} ");
            }

            Console.ReadKey(true);
        }
    }
}
