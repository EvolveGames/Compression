using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            char[] viewChar = new char[7] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            ConsoleColor[] viewCharColors = new ConsoleColor[7] { ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Cyan, ConsoleColor.DarkGreen, ConsoleColor.Blue, ConsoleColor.DarkYellow };


            byte[] FileBytes = File.ReadAllBytes("test.txt");
            Console.WriteLine("Original: ");


            CompressEngine.WriteBytes(FileBytes, viewChar, viewCharColors);


            FileBytes = CompressEngine.BasicCompressBytes(FileBytes);


            Console.WriteLine();
            Console.WriteLine("Compresed: ");


            CompressEngine.WriteBytes(FileBytes, viewChar, viewCharColors);


            File.WriteAllBytes("data.lol", FileBytes);
            Console.ReadKey(true);
        }
    }
}
