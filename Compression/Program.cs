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
            byte[] FileBytes = File.ReadAllBytes("test_TNT.png");
            Console.WriteLine("Original: ");
            CompressEngine.WriteBytes(FileBytes, new char[3] { 'A', 'B', 'C' }, new ConsoleColor[3] {ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Magenta });
            FileBytes = CompressEngine.BasicCompressBytes(FileBytes);
            Console.WriteLine();
            Console.WriteLine("Compresed: ");
            CompressEngine.WriteBytes(FileBytes, new char[3] { 'A', 'B', 'C' }, new ConsoleColor[3] { ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Magenta });
            File.WriteAllBytes("data.lol", FileBytes);
            Console.ReadKey(true);
        }
    }
}
