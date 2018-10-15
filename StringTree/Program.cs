using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileRead;

namespace StringTree
{
    class Program
    {
        private static string filename;

        private static FileReader fileReader = new FileReader();

        private static TreeMaker treeMaker = new TreeMaker();

        static void Main()
        {
            Console.WriteLine("Enter filename (including relative path) to read data from:\n" +
                              "   (Best to place text file in Debug folder)");
            filename = Console.ReadLine();

            var fileInfo = fileReader.ReadFile(AppDomain.CurrentDomain.BaseDirectory, filename);

            Console.WriteLine("Now parsing data from text file...\n");

            treeMaker.LoadText(fileInfo);

            Console.ReadKey();
        }
    }
}
